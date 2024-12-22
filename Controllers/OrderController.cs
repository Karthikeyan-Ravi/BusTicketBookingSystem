using BusTicketBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusTicketBookingSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OrderHistory()
        {
            var userId = HttpContext.Session.GetString("UserId"); // Assume UserId is stored in session
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            // Fetch order history for the user
            var orderHistory = _context.Bookings
                .Where(b => b.UserId == int.Parse(userId))
                .Select(b => new OrderHistoryViewModel
                {
                    BookingId = b.Id,
                    BusName = b.Bus.Name,
                    Source = b.Bus.Source,
                    Destination = b.Bus.Destination,
                    TravelDate = b.BookingDate.Date,
                    Seats = b.SeatNumbers
                }).ToList();

            return View(orderHistory);
        }

    }
}
