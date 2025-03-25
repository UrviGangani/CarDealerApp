using System.ComponentModel.DataAnnotations;
namespace CarDealerApp.Models.ViewModel{
    public class RegisterViewModel
    {
        // [Required]
        // [EmailAddress]
        // public string Email { get; set; }

        // [Required]
        // [StringLength(100, ErrorMessage = "First name cannot be longer than 100 characters.")]
        // public string FirstName { get; set; }

        // [Required]
        // [StringLength(100, ErrorMessage = "Last name cannot be longer than 100 characters.")]
        // public string LastName { get; set; }

        // [Required]
        // [DataType(DataType.Password)]
        // public string Password { get; set; }

        // [Required]
        // [DataType(DataType.Password)]
        // [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        // public string ConfirmPassword { get; set; }
        // public bool IsAdmin { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public bool IsAdmin { get; set; }

    }

}
