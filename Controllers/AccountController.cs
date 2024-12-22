using BusTicketBookingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusTicketBookingSystem.Controllers
{
    public class AccountController : Controller
    {
        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;

        public User userDetails;

        private readonly ApplicationDbContext _context;

        //public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;

        //}
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Login implementation starts from here

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _context.Users.FirstOrDefaultAsync(
                                    u => u.Email == model.Email && u.Password == model.Password);
                    if(user == null)
                    {
                        var newUser = new User
                        {
                            Username = model.FullName,
                            Email = model.Email,
                            Password = model.Password //Use Hashing to securely save the password
                        };

                        _context.Users.Add(newUser);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError("", "User already exist");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return View(model);
        }

        //Login implementation starts from here

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    HttpContext.Session.SetString("UserId", user.UserId.ToString());
                    //HttpContext.Session.SetString("UserEmail", user.Email);
                    //userDetails = new User
                    //{
                    //    UserId = user.UserId,
                    //    Username = user.Username,
                    //    Email = user.Email
                    //};
                    // Logic to handle successful login, like setting cookies or session
                    return RedirectToAction("SearchBus", "Bus"); // Redirect to homepage or dashboard
                }
                HttpContext.Session.Remove("UserId");
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                HttpContext.Session.Remove("UserId");
            }
            return RedirectToAction("SearchBus", "Bus");
        }

    }
}
