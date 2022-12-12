using AuthenticationPlugin;
using AutoMapper;
using CinemaAPI.Dto;
using CinemaAPI.Models;
using CinemaAPI.Repository;

namespace CinemaAPI.Service {
    public class UserService : IUserService {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepo userRepo, IMapper mapper) {
            this._userRepo = userRepo;
            this._mapper = mapper;
        }

        public UserDto RegisterUser(AddUserDto addUserDto) {

            User user = _mapper.Map<AddUserDto, User>(addUserDto);
            user.Role = "User";
            user.Password = SecurePasswordHasherHelper.Hash(addUserDto.Password);
            var createdUser = _userRepo.RegisterUser(user);
            var userDto = _mapper.Map<User, UserDto>(createdUser);

            return userDto;
        }




        public bool CheckIfEmailExist(string email) {
            var exist =  _userRepo.CheckIfUserExistByEmail(email);

            if(exist == null) {
                return false;
            }

            return true;
        }

        public User FindUserByEmail(string email) {
            return _userRepo.CheckIfUserExistByEmail(email);
        }
    }
}
