using CinemaAPI.Dto;
using CinemaAPI.Models;

namespace CinemaAPI.Service {
    public interface IMoviesService {

        public List<DisplayMoviesDto> GetAllMovies();
        public Movie GetMovieById(int id);
        public MovieDto AddMovie(AddMovieDto addMoviedto);
        public Movie UpdateMovie(int id, AddMovieDto updateMovieDto);
        public Boolean DeleteMovie(int id);
        public IQueryable FindMovies(string name);
    }
}
