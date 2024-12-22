namespace BusTicketBookingSystem.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }  // True if the seat is available for booking
        public int SeatNumber { get; set; }

        // Foreign key to Bus
        public int BusId { get; set; }
        public Bus Bus { get; set; }

    }
}
