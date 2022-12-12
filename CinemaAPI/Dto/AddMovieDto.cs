using CinemaAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaAPI.Dto {
    public class AddMovieDto {
        //[Required(ErrorMessage = "Name cannot be null")]
        //no need for this on .net 6 fields since default is required unless you specify the prop can be nullable with "?"
        //only use it if you want to display a personalkized messaje for empty values
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
        public string? ImageUrl { get; set; }


        [NotMapped] //not maped does not in clude the field in to the DB
        public IFormFile File { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }
    }
}
