using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaAPI.Models {
    public class Movie {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public double Rate { get; set; }

        [NotMapped] //not maped does not in clude the field in to the DB
        public IFormFile File { get; set; }

        public string ImageUrl { get; set; }

    }
}
