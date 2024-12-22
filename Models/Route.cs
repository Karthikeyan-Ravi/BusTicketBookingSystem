namespace BusTicketBookingSystem.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }  // Price for a ticket on this route

        // Foreign key to the Bus
        public int BusId { get; set; }
        public Bus Bus { get; set; }
    }
}
