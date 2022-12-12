using CinemaAPI.Data;
using CinemaAPI.Models;

namespace CinemaAPI.Repository {
    public class UserRepo : IUserRepo {
        private readonly CinemaDbContext _cinemaDbContext;

        public UserRepo(CinemaDbContext cinemaDbContext) {
            this._cinemaDbContext = cinemaDbContext;
        }

        public User RegisterUser(User user) {
            _cinemaDbContext.Users.Add(user);
            _cinemaDbContext.SaveChanges();
            return user;
        }




        public bool CheckIfEmailExist(string email) {

            var userWithSameEmail = _cinemaDbContext.Users.Where( u => u.Email == email ).SingleOrDefault();

            if (userWithSameEmail != null) {
                return true;
            }

            return false;
        }
    }
}
