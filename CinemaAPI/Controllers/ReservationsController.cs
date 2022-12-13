using CinemaAPI.Models;
using CinemaAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : Controller {
        private readonly IReservationsService _reservationsService;

        public ReservationsController(IReservationsService reservationsService) {
            this._reservationsService = reservationsService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll() {
            return Ok(_reservationsService.GetAllReservations());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public IActionResult GetReservationById([FromRoute]int id) {
            return Ok(_reservationsService.GetReservationById(id));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Reservation reservation) {
            var reservationAdded = _reservationsService.AddResservation(reservation);
            return Created("", reservationAdded);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteById(int id) {
            return _reservationsService.deleteReservationById(id) ? Ok("Reservation deleted") : NotFound("Reservation not found");
        }
    }
}
