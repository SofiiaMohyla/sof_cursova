using sof_curs.Entity;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace sof_curs.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Please enter at least 4 characters for the Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Please enter a valid email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Please enter a password with at least 6 characters")]
        public string Password { get; set; }

        public User ToUser()
        {
            return new User
            {
                Name = Name,
                Email = Email,
                Password = Password
            };
        }
    }
}
