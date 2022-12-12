using CinemaAPI.Dto;
using CinemaAPI.Models;

namespace CinemaAPI.Service {
    public interface IUserService {

        public UserDto RegisterUser(AddUserDto addUserDto);
        public Boolean CheckIfEmailExist(string email);

        public User FindUserByEmail(string email);

    }
}
