using CinemaAPI.Models;

namespace CinemaAPI.Repository {
    public interface IMoviesRepository {

        public List<Movie> GetAllMovies();
        public Movie GetMovieById(int id);
        public Movie AddMovie(Movie movie);
        public Movie UpdateMovie(int id, Movie movie);
    }
}
