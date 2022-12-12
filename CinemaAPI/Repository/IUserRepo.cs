using CinemaAPI.Models;

namespace CinemaAPI.Repository {
    public interface IUserRepo {
        public Boolean CheckIfEmailExist(string email);
        public User RegisterUser(User user);

    }
}
