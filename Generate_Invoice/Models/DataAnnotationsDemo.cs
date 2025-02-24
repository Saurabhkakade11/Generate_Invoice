using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Generate_Invoice.Models
{
    public class DataAnnotationsDemo
    {
        [Key] // Primary Key
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Mobile number must be 10 digits.")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60.")]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [CustomValidation(typeof(CustomValidator), nameof(CustomValidator.ValidateSalary))]
        public int Salary { get; set; }

        [Required]
        [CreditCard(ErrorMessage = "Invalid credit card number.")]
        public string CreditCardNumber { get; set; }

        [Required]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string Website { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan PreferredContactTime { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")] // Only for databases that support money type
        public decimal AccountBalance { get; set; }

        [ScaffoldColumn(false)] // Hides from auto-generated UI forms
        public string HiddenField { get; set; }

        [Timestamp] // For concurrency checking
        public byte[] RowVersion { get; set; }

        [NotMapped] // Excludes from database schema
        public string TemporaryValue { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png,gif", ErrorMessage = "Only image files are allowed.")]
        public string ProfilePicture { get; set; }
    }

    public class CustomValidator
    {
        public static ValidationResult ValidateSalary(int salary, ValidationContext context)
        {
            return salary >= 10000 ? ValidationResult.Success : new ValidationResult("Salary must be at least 10,000.");
        }
    }
}
