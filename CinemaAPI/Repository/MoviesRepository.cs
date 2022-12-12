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
            movieOld.Description = movie.Description;
            movieOld.Language = movie.Language;
            movieOld.Duration = movie.Duration;
            movieOld.PlayingDate = movie.PlayingDate;
            movieOld.PlayingTime = movie.PlayingTime;
            movieOld.TicketPrice = movie.TicketPrice;
            movieOld.Rating = movie.Rating;
            movieOld.Genre = movie.Genre;
            movieOld.TrailerUrl = movie.TrailerUrl;
            movieOld.ImageUrl = movie.ImageUrl;
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

        public IQueryable FindMovies(string movieName) {
            var movies = from movie in _cinemaDbContext.Movies
                         where movie.Name.StartsWith(movieName.ToLower()) || movie.Name.StartsWith(movieName.ToUpper())
                         select new {
                             Id = movie.Id,
                             Name = movie.Name,
                             ImageUrl = movie.ImageUrl,
                         };

            return movies;
        }
    }
}
