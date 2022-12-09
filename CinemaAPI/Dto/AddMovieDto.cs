namespace CinemaAPI.Dto {
    public class AddMovieDto {
        public string Name { get; set; }
        public string Language { get; set; }
        public double Rate { get; set; }
        public IFormFile File { get; set; }
        public string ImageUrl { get; set; }
    }
}
