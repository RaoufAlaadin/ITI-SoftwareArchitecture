using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Demo.DTO
{
    public class RegisterUserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage ="Your password do not match,my friendo.")]
        public string ConfirmPassword { get; set; } 
        public string Email { get; set; }


    }
}
