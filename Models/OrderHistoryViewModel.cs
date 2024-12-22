namespace BusTicketBookingSystem.Models
{
    public class OrderHistoryViewModel
    {
        public int BookingId { get; set; }
        public string BusName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime TravelDate { get; set; }
        public string Seats { get; set; }
        //public decimal TotalAmount { get; set; }
    }
}
