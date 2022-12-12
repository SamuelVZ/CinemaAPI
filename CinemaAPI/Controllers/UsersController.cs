using CinemaAPI.Data;
using CinemaAPI.Dto;
using CinemaAPI.Models;
using CinemaAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) {
            this._userService = userService;
        }


        [HttpPost]
        public IActionResult Register([FromBody] AddUserDto addUserDto) {
            var emailExist = _userService.CheckIfEmailExist(addUserDto.Email);
            if (emailExist) {
                return BadRequest("Email " + addUserDto.Email + " already exist. Use a different email");
            }

            var user = _userService.RegisterUser(addUserDto);

            return StatusCode(StatusCodes.Status201Created, user);
        }
    }
}
