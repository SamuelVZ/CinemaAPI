using CinemaAPI.Models;

namespace CinemaAPI.Repository {
    public interface IUserRepo {
        public User CheckIfUserExistByEmail(string email);
        public User RegisterUser(User user);

    }
}
