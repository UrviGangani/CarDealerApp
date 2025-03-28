using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealerApp.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required] public string Make { get; set; } = string.Empty;
        [Required] public string Model { get; set; } = string.Empty;
        [Required] public int Year { get; set; } = 0;
        [Required] public decimal Price { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        [Required] public string ImageUrl { get; set; } = string.Empty;

        public List<Inquiry> Inquiries { get; set; } = new List<Inquiry>();
        public int InquiryCount => Inquiries?.Count ?? 0;
    }
}
