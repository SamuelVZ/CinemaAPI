namespace CinemaAPI.Dto {
    public class ReservationDetails {
        public int Id { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public string Phone { get; set; }
        public DateTime ReservationTime { get; set; }
        public int CustomerName { get; set; }
        public string MovieName { get; set; }
        public string Email { get; set; }
        public DateTime PlayingDate { get; set; }
        public DateTime PlatingTime { get; set; }

    }
}
