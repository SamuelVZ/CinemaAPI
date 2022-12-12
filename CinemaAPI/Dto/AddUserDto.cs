using CinemaAPI.Models;

namespace CinemaAPI.Dto {
    public class AddUserDto {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string Role { get; set; }

        //1 to many relationship
        //public ICollection<Reservation> Reservations { get; set; }
    }
}
