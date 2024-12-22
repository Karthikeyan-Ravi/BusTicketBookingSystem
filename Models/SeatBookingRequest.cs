namespace BusTicketBookingSystem.Models
{
    public class SeatBookingRequest
    {
        public int BusId { get; set; } // The ID of the selected bus

        public List<int> SelectedSeatNumbers { get; set; } // List of seat numbers selected for booking
    }

}
