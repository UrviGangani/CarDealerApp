using System.ComponentModel.DataAnnotations;

public class Car
{
    public int Id { get; set; }

    [Required]
    public string Make { get; set; }

    [Required]
    public string Model { get; set; }

    public int Year { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; }
}
