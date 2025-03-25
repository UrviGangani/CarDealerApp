using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealerApp.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensures auto-increment
        public int Id { get; set; }
        [Required]  public string Make { get; set; } = string.Empty;
        [Required]  public string Model { get; set; } = string.Empty;
        [Required] public int Year { get; set; } = 0;
        [Required] public decimal Price { get; set; } = 0;
        [Required]  public string ImageUrl { get; set; } = string.Empty;
    }
}
