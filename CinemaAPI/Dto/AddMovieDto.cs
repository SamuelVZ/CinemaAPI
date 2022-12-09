using System.ComponentModel.DataAnnotations;

namespace CinemaAPI.Dto {
    public class AddMovieDto {
        //[Required(ErrorMessage = "Name cannot be null")]
        //no need for this on .net 6 fields since default is required unless you specify the prop can be nullable with "?"
        //only use it if you want to display a personalkized messaje for empty values
        public string Name { get; set; }
        public string Language { get; set; }
        public double Rate { get; set; }
        public IFormFile? File { get; set; }
        public string? ImageUrl { get; set; }
    }
}
