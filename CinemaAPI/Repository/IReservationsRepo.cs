﻿using CinemaAPI.Dto;
using CinemaAPI.Models;

namespace CinemaAPI.Repository {
    public interface IReservationsRepo {
        public Reservation AddResservation(Reservation reservation);
        public IQueryable GetAllReservations();
        public ReservationDetails GetReservationById(int id);
        public Boolean deleteReservationById(int id);
    }
}
