namespace BusTicketBookingSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BusId { get; set; }
        public DateTime BookingDate { get; set; }
        public int SeatsBooked { get; set; }
        public string SeatNumbers { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Bus Bus { get; set; }
    }
}
