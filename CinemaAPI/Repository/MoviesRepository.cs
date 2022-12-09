using CinemaAPI.Data;
using CinemaAPI.Dto;
using CinemaAPI.Models;

namespace CinemaAPI.Repository {
    public class MoviesRepository : IMoviesRepository {
        private readonly CinemaDbContext _cinemaDbContext;

        public MoviesRepository(CinemaDbContext cinemaDbContext) {
            this._cinemaDbContext = cinemaDbContext;
        }

        
        public List<Movie> GetAllMovies() {
            return _cinemaDbContext.Movies.ToList();
        }

        public Movie GetMovieById(int id) {
            return _cinemaDbContext.Movies.FirstOrDefault(x => x.Id == id);
        }

        public Movie AddMovie(Movie movie) {
            _cinemaDbContext.Movies.Add(movie);
            _cinemaDbContext.SaveChanges();
            return movie;
        }

        public Movie UpdateMovie(int id, AddMovieDto movie) {
            var movieOld = GetMovieById(id);

            movieOld.Name = movie.Name;
            movieOld.Language = movie.Language;
            //_cinemaDbContext.Movies.Update(movieOld);
            _cinemaDbContext.SaveChanges();

            return movieOld;
        }

        public bool DeleteMovie(Movie movie) {

            if (movie == null) {
                return false;
            }

            _cinemaDbContext.Remove(movie);
            _cinemaDbContext.SaveChanges();
            return true;
        }
    }
}
