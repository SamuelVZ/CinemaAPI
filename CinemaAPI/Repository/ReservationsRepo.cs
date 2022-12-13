using CinemaAPI.Data;
using CinemaAPI.Dto;
using CinemaAPI.Models;

namespace CinemaAPI.Repository {
    public class ReservationsRepo : IReservationsRepo {
        private readonly CinemaDbContext _cinemaDbContext;

        public ReservationsRepo(CinemaDbContext cinemaDbContext) {
            this._cinemaDbContext = cinemaDbContext;
        }

        public Reservation AddResservation(Reservation reservation) {
            _cinemaDbContext.Reservations.Add(reservation);
            _cinemaDbContext.SaveChanges();
            return reservation;
        }

        public IQueryable GetAllReservations() {
            var reservations = from reservation in _cinemaDbContext.Reservations
                               join customer in _cinemaDbContext.Users on reservation.UserId equals customer.Id
                               join movie in _cinemaDbContext.Movies on reservation.MovieId equals movie.Id
                               select new {
                                   Id = reservation.Id,
                                   ReservationTime = reservation.ReservationTime,
                                   CustomerName = customer.Email,
                                   MovieName = movie.Name,
                               };

            return reservations;
        }

        public ReservationDetails GetReservationById(int id) {
            var reservationById = (from reservation in _cinemaDbContext.Reservations
                               join customer in _cinemaDbContext.Users on reservation.UserId equals customer.Id
                               join movie in _cinemaDbContext.Movies on reservation.MovieId equals movie.Id

                               where reservation.Id == id

                               select new ReservationDetails {
                                   Id = reservation.Id,
                                   ReservationTime = reservation.ReservationTime,
                                   CustomerName = customer.Id,
                                   MovieName = movie.Name,
                                   Email = customer.Email,
                                   Qty = reservation.Qty,
                                   Price =reservation.Price,
                                   Phone = reservation.Phone,
                                   PlayingDate = movie.PlayingDate,
                                   PlatingTime = movie.PlayingTime,

                               }).FirstOrDefault();

            return reservationById;
        }

        public bool deleteReservationById(int id) {

            var reservation = _cinemaDbContext.Reservations.Find(id);

            if (reservation == null) {
                return false;
            }

            _cinemaDbContext.Remove(reservation);
            _cinemaDbContext.SaveChanges();
            return true;
        }


    }
}
