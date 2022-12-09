using CinemaAPI.Dto;
using CinemaAPI.Models;

namespace CinemaAPI.Service {
    public interface IMoviesService {

        public List<Movie> GetAllMovies();
        public Movie GetMovieById(int id);
        public MovieDto AddMovie(AddMovieDto addMoviedto);
        public Movie UpdateMovie(int id, AddMovieDto updateMovieDto);
        public Boolean DeleteMovie(int id);
    }
}
