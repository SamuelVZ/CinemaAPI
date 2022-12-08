using AutoMapper;
using CinemaAPI.Dto;
using CinemaAPI.Models;
using CinemaAPI.Repository;

namespace CinemaAPI.Service {
    public class MoviesService : IMoviesService {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;

        public MoviesService(IMoviesRepository moviesRepository, IMapper mapper) {
            this._moviesRepository = moviesRepository;
            this._mapper = mapper;
        }

        public MovieDto AddMovie(AddMovieDto addMoviedto) {
            Movie movie = _mapper.Map<AddMovieDto, Movie>(addMoviedto);

            Movie addedMovie =  _moviesRepository.AddMovie(movie);

            MovieDto addedMovieDto = _mapper.Map<Movie, MovieDto>(addedMovie);

            return addedMovieDto;
        }

        public List<Movie> GetAllMovies() {
            return _moviesRepository.GetAllMovies();
        }

        public Movie GetMovieById(int id) {
            return _moviesRepository.GetMovieById(id);
        }
    }
}
