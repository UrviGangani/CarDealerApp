using System.ComponentModel.DataAnnotations;
namespace CarDealerApp.Models.ViewModel{
    public class LoginViewModel
    {
        // [Required]
        // [EmailAddress]
        // public required string Email { get; set; }

        // [Required]
        // [DataType(DataType.Password)]
        public required string Email { get; set; }
        public required string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
