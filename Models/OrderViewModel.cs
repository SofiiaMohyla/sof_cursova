using Microsoft.AspNetCore.Mvc.Rendering;
using sof_curs.Entity;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
        [DateGreaterThanOrEqualCurrentDate(ErrorMessage = "Please enter a date that is greater than or equal to the current date")]
        [DateFormat(ErrorMessage = "Date format should be DD.MM.YYYY")]
        [DateRange(ErrorMessage = "Incorrect input of date")]
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

    public class DateGreaterThanOrEqualCurrentDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is string dateString)
            {
                if (DateTime.TryParseExact(dateString, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    if (date >= DateTime.Today)
                    {
                        return ValidationResult.Success;
                    }
                }
            }

            return new ValidationResult(ErrorMessage);
        }
    }

    public class DateFormatAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string dateString)
            {
                string pattern = @"^\d{2}\.\d{2}\.\d{4}$";
                if (Regex.IsMatch(dateString, pattern))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage);
        }
    }

    public class DateRangeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is string dateString)
            {
                if (DateTime.TryParseExact(dateString, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    if (date.Day >= 1 && date.Day <= 31 && date.Month >= 1 && date.Month <= 12 && date.Year >= 0)
                    {
                        return ValidationResult.Success;
                    }
                }
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
