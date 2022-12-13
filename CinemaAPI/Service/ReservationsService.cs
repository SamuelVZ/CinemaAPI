using CinemaAPI.Dto;
using CinemaAPI.Models;
using CinemaAPI.Repository;

namespace CinemaAPI.Service {
    public class ReservationsService : IReservationsService{
        private readonly IReservationsRepo _reservationsRepo;

        public ReservationsService(IReservationsRepo reservationsRepo) {
            this._reservationsRepo = reservationsRepo;
        }

        public Reservation AddResservation(Reservation reservation) {
            reservation.ReservationTime = DateTime.Now;
            return _reservationsRepo.AddResservation(reservation);
        }

        public IQueryable GetAllReservations() {
            return _reservationsRepo.GetAllReservations();
        }

        public ReservationDetails GetReservationById(int id) {
            return _reservationsRepo.GetReservationById(id);
        }
        public bool deleteReservationById(int id) {
            return _reservationsRepo.deleteReservationById(id);
        }

    }
}
