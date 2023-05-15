using Microsoft.AspNetCore.Mvc.Rendering;
using sof_curs.Entity;
using System.ComponentModel.DataAnnotations;

namespace sof_curs.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Please enter at least 4 chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Please enter at least 4 chars")]
        [EmailAddress(ErrorMessage = "Wrong Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Please enter at least 4 chars")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Please enter at least 4 chars")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Time is required")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Please enter at least 4 chars")]
        public string Time { get; set; }

        [Required(ErrorMessage = "Number of people is required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Please enter a valid numeric value.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Please enter at least 1 char")]
        public string NumberOfPeople { get; set; } 
        public string? Message { get; set; }

        public Order ToOrder()
        {
            return new Order
            {
                Name = Name,
                Email = Email,
                Phone = Phone,
                Date = Date,
                Time = Time,
                NumberOfPeople = NumberOfPeople,
                Message = Message ?? "Empty"
            };
        }
    }
}
