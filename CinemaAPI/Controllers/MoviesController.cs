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
            var movie = _moviesService.GetMovieById(id);

            return movie != null ? Ok(movie): NotFound("Movie with id " + id + " does not exist") ;
        }

        [HttpPost] 
        public IActionResult Add([FromBody]AddMovieDto addMovieDto) {
            var movie = _moviesService.AddMovie(addMovieDto);
            return Created("", movie);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AddMovieDto movie) {
            var updatedMovie = _moviesService.UpdateMovie(id, movie);
            return updatedMovie != null ? Ok(updatedMovie) : NotFound("Movie with id " + id + " does not exist");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id) {
            var deleted = _moviesService.DeleteMovie(id);

            return deleted ? Ok("Movie deleted") : NotFound("The movie tried to delete does not exist");
        }
    }
}
