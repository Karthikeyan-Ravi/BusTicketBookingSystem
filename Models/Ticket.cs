namespace BusTicketBookingSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BusId { get; set; }
        public DateTime BookingDate { get; set; }
        public int SeatNumber { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public Bus Bus { get; set; }
    }
}
