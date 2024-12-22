namespace BusTicketBookingSystem.Models
{
    public class Bus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public int TotalSeats { get; set; }

        // Add a collection for routes
        public ICollection<Route> Routes { get; set; }

        // Add a collection for seats (optional depending on your design)
        public ICollection<Seat> Seats { get; set; }
    }
}
