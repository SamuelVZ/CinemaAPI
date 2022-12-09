using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaAPI.Models {
    public class Movie {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Duration { get; set; }
        public DateTime PlayingDate { get; set; }
        public DateTime PlayingTime { get; set; }
        public double TicketPrice { get; set; }
        public double Rating { get; set; }
        public string Genre { get; set; }
        public string TrailerUrl { get; set; }
        public string ImageUrl { get; set; }


        [NotMapped] //not maped does not in clude the field in to the DB
        public IFormFile File { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}
