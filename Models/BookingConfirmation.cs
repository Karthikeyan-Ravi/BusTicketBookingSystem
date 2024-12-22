namespace BusTicketBookingSystem.Models
{
    public class BookingConfirmation
    {
        public int BookingId { get; set; }
        public string BusName { get; set; }
        public List<string> SeatNumbers { get; set; }
        public DateTime BookingDate { get; set; }
        public Bus BusDetails { get; set; }
    }
}
