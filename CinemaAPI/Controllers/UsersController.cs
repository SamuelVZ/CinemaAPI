using AuthenticationPlugin;
using CinemaAPI.Data;
using CinemaAPI.Dto;
using CinemaAPI.Models;
using CinemaAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CinemaAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller {
        private readonly IUserService _userService;
        private IConfiguration _configuration;
        private readonly AuthService _auth;

        public UsersController(IUserService userService, IConfiguration configuration) {
            this._userService = userService;
            this._configuration = configuration;
            this._auth = new AuthService(_configuration);
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult Register([FromBody] AddUserDto addUserDto) {
            var emailExist = _userService.CheckIfEmailExist(addUserDto.Email);
            if (emailExist) {
                return BadRequest("Email " + addUserDto.Email + " already exist. Use a different email");
            }

            var user = _userService.RegisterUser(addUserDto);

            return StatusCode(StatusCodes.Status201Created, user);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] LoginDto user) {
            var checkEmail = _userService.CheckIfEmailExist(user.Email);

            if (checkEmail == false) {
                return NotFound("User not found");
            }

            var userFound = _userService.FindUserByEmail(user.Email);

            if (!SecurePasswordHasherHelper.Verify(user.Password, userFound.Password)) {
                return Unauthorized();
            }

            var claims = new[]
            {
               new Claim(JwtRegisteredClaimNames.Email, user.Email),
               new Claim(ClaimTypes.Email, user.Email),
               new Claim(ClaimTypes.Role, userFound.Role)
             };

            var token = _auth.GenerateAccessToken(claims);

            return new ObjectResult(new {
                access_token = token.AccessToken,
                expires_in = token.ExpiresIn,
                token_type = token.TokenType,
                creation_Time = token.ValidFrom,
                expiration_Time = token.ValidTo,
                user_id = userFound.Id,
            });

        }

        //[HttpGet]
        //[Authorize(Roles = "User")] //Authorize is to only give access to jwt bearer tokens, with role we assure only user with that role have acces to that request
        //[Route("[action]")]
        //public IActionResult AuthorizationUserTest() {
        //    return Ok( "Hello User");
        //}

        //[HttpGet]
        //[Authorize(Roles = "Admin")]
        //[Route("[action]")]
        //public IActionResult AuthorizationAdminTest() {
        //    return Ok("Hello Admin");
        //}
    }
}
