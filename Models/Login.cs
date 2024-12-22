﻿using System.ComponentModel.DataAnnotations;

namespace BusTicketBookingSystem.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}