using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller {

        List<Movie> movies = new List<Movie> {
            new Movie(){ Id = 0, Name = "Interestellar", Language = "English"},
            new Movie(){ Id = 1, Name = "MadMax", Language = "English"},
        };
        [HttpGet]
        public IActionResult Index() {
            return Ok(movies);
        }

        [HttpPost] 
        public IActionResult Add([FromBody]Movie movie) {
            movies.Add(movie);
            return Ok(movies);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody]Movie movie) {
            movies[id] = movie;
            return Ok(movies);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]int id) {
            movies.RemoveAt(id);
            return Ok(movies);
        }
    }
}
