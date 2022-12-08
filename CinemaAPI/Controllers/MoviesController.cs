using CinemaAPI.Dto;
using CinemaAPI.Models;
using CinemaAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller {

        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService) {
            this._moviesService = moviesService;
        }

        //List<Movie> movies = new List<Movie> {
        //    new Movie(){ Id = 0, Name = "Interestellar", Language = "English"},
        //    new Movie(){ Id = 1, Name = "MadMax", Language = "English"},
        //};

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_moviesService.GetAllMovies());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMovieById([FromRoute]int id) {
            return Ok(_moviesService.GetMovieById(id));
        }

        [HttpPost] 
        public IActionResult Add([FromBody]AddMovieDto addMovieDto) {
            var movie = _moviesService.AddMovie(addMovieDto);
            return Ok(movie);
        }

        //[HttpPut]
        //[Route("{id}")]
        //public IActionResult Put([FromRoute]int id, [FromBody]Movie movie) {
        //    movies[id] = movie;
        //    return Ok(movies);
        //}

        //[HttpDelete]
        //[Route("{id}")]
        //public IActionResult Delete([FromRoute]int id) {
        //    movies.RemoveAt(id);
        //    return Ok(movies);
        //}
    }
}
