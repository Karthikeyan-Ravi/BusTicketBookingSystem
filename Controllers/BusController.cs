using BusTicketBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BusTicketBookingSystem.Controllers
{
    public class BusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchBus()
        {
            return View(new SearchBus());
        }

        [HttpPost]
        public IActionResult SearchBus(SearchBus model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                // Fetch routes that match the user's search criteria
                var matchingRoutes = _context.Routes.Include(r => r.Bus)
                    .Where(r => r.DepartureLocation == model.Source &&
                                r.ArrivalLocation == model.Destination &&
                                r.DepartureTime.Date == model.TravelDate.Date)
                    .ToList();

                var temp = _context.Buses.Where(r => r.Destination == model.Destination 
                            && r.Source == model.Source && r.DepartureTime.Date == model.TravelDate.Date).ToList();

                // Pass results to the Search Results View
                return View("SearchResults", matchingRoutes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);
            }
        }

        // Implementation of view seats logic

        public IActionResult ViewSeats(int busId)
        {
            // Fetch the selected bus
            var bus = _context.Buses
                .Include(b => b.Seats)
                .FirstOrDefault(b => b.Id == busId);
            
            if (bus == null)
            {
                return NotFound("Bus not found.");
            }

            var seats = _context.Seats
                .Where(s => s.BusId == busId)
                .OrderBy(s => s.SeatNumber) // Ensure seats are ordered
                .ToList();

            var seats1 = bus.Seats.Select(s => new SeatView
            {
                SeatNumber = s.SeatNumber,
                IsAvailable = s.IsAvailable
            }).ToList();

            // Map data to the View Model
            var viewModel = new SeatAvailability
            {
                BusId = bus.Id,
                BusName = bus.Name,
                Seats = seats.Select(s => new SeatView
                {
                    SeatNumber = s.SeatNumber,
                    IsAvailable = s.IsAvailable
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult BookSeats(SeatBookingRequest request)
        {
            string? userId = HttpContext.Session.GetString("UserId") != null ?
                                HttpContext.Session.GetString("UserId") : string.Empty;
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            if (request.SelectedSeatNumbers == null || request.SelectedSeatNumbers.Count() == 0)
            {
                ModelState.AddModelError("", "Please select at least one seat.");
                return RedirectToAction("ViewSeats", new { busId = request.BusId });
            }

            // Fetch selected seats
            var seats = _context.Seats
                .Where(s => request.SelectedSeatNumbers != null &&
                request.SelectedSeatNumbers.Contains(s.SeatNumber) && s.BusId == request.BusId)
                .ToList();

            // Check if any selected seat is already booked
            if (seats.Any(s => !s.IsAvailable))
            {
                ModelState.AddModelError("", "Some of the selected seats are already booked.");
                return RedirectToAction("ViewSeats", new { busId = request.BusId });
            }

            // Update seat availability
            foreach (var seat in seats)
            {
                seat.IsAvailable = false; // Mark as booked
            }

            // Save booking details
            var booking = new Booking
            {
                UserId = Convert.ToInt32(userId),
                BusId = request.BusId,
                SeatNumbers = string.Join(",", request.SelectedSeatNumbers),
                SeatsBooked = request.SelectedSeatNumbers.Count(),
                BookingDate = DateTime.Now
            };
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Booking successful!";
            return RedirectToAction("BookingConfirmation", new { bookingId = booking.Id });
        }

        public IActionResult BookingConfirmation(int bookingId)
        {
            string? userId = HttpContext.Session.GetString("UserId") != null ?
                                HttpContext.Session.GetString("UserId") : string.Empty;
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }
            var booking = _context.Bookings
                .Include(b => b.Bus)
                .FirstOrDefault(b => b.Id == bookingId);

            if (booking == null)
            {
                return NotFound("Booking not found.");
            }

            var viewModel = new BookingConfirmation
            {
                BookingId = booking.Id,
                BusName = booking.Bus.Name,
                SeatNumbers = booking.SeatNumbers.Split(',').ToList(),
                BookingDate = booking.BookingDate,
                BusDetails = booking.Bus
            };

            return View(viewModel);
        }

    }
}
