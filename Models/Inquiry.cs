using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealerApp.Models
{
    public class Inquiry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }  // Foreign Key to AspNetUsers (User making the inquiry)

        [Required]
        public int CarId { get; set; }  // Foreign Key to Cars Table

        [Required]
        public string Message { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey("CarId")]
        public Car Car { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
    

}
