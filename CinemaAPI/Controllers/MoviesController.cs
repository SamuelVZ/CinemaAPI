using CinemaAPI.Dto;
using CinemaAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller {

        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService) {
            this._moviesService = moviesService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll(string? sort, int? pageNumber, int? pageSize) {

            var currentPageNumber = pageNumber ?? 1; // if variable is null, then the value is assigned with the ?? operator
            var currentPageSize = pageSize ?? 2;


            var movies = _moviesService.GetAllMovies();
            
            switch (sort) {
                case "desc":
                    return Ok(movies.OrderByDescending(m => m.Rating));
                case "asc":
                    return Ok(movies.OrderBy(m => m.Rating));
                default:
                    return Ok(movies.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public IActionResult GetMovieById([FromRoute]int id) {
            var movie = _moviesService.GetMovieById(id);

            return movie != null ? Ok(movie): NotFound("Movie with id " + id + " does not exist") ;
        }

        //[HttpGet] //to access this method "api/movies/test/2"
        //[Route("[action]/{id}")]
        //public int Test(int id) {
        //    return id;
        //}

        //[HttpPost] 
        //public IActionResult Add([FromBody]AddMovieDto addMovieDto) {
        //var movie = _moviesService.AddMovie(addMovieDto);
        //    return Created("", movie);
        //}

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromForm] AddMovieDto addMovieDto) {
            var guid = Guid.NewGuid();
            var filePath = Path.Combine("wwwroot", guid+".jpg");

            if (addMovieDto.File != null) {
                var fileStream = new FileStream(filePath, FileMode.Create);
                addMovieDto.File.CopyTo(fileStream);
            }

            addMovieDto.ImageUrl = filePath.Remove(0,7);
            var movie = _moviesService.AddMovie(addMovieDto);
            return Created("", movie);

 
        }

        //[HttpPut]
        //[Route("{id}")]
        //public IActionResult Put([FromRoute] int id, [FromBody] AddMovieDto movie) {
        //    var updatedMovie = _moviesService.UpdateMovie(id, movie);
        //    return updatedMovie != null ? Ok(updatedMovie) : NotFound("Movie with id " + id + " does not exist");
        //}
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromForm] AddMovieDto movie) {

            var findMovie = _moviesService.GetMovieById(id);
            if (findMovie == null) {
                return NotFound("Movie with id " + id + " does not exist");

            }

            var guid = Guid.NewGuid();
            var filePath = Path.Combine("wwwroot", guid + ".jpg");

            if (movie.File != null) {
                var fileStream = new FileStream(filePath, FileMode.Create);
                movie.File.CopyTo(fileStream);
                movie.ImageUrl = filePath.Remove(0, 7);

            }

            var movieUpdated = _moviesService.UpdateMovie(id, movie);
            return Created("", movieUpdated);


            //return updatedMovie != null ? Ok(updatedMovie) : NotFound("Movie with id " + id + " does not exist");
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id) {
            var deleted = _moviesService.DeleteMovie(id);

            return deleted ? Ok("Movie deleted") : NotFound("The movie tried to delete does not exist");
        }


        [HttpGet]
        //[Authorize]
        [Route("[action]")]
        public IActionResult FindMovies(string name) {
            return Ok( _moviesService.FindMovies(name));

        }
    }
}
