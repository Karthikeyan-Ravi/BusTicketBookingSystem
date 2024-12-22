namespace BusTicketBookingSystem.Models
{
    public class SeatAvailability
    {
        public int BusId { get; set; }
        public string BusName { get; set; }
        public List<SeatView> Seats { get; set; }
    }
    public class SeatView
    {
        public int SeatNumber { get; set; }
        public bool IsAvailable { get; set; }
    }
}
