using CinemaAPI.Models;

namespace CinemaAPI.Dto {
    public class UserDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        //1 to many relationship
        public ICollection<Reservation> Reservations { get; set; }
    }
}
