using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CarDealerApp.Models; 
using CarDealerApp.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class ApiCarsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public ApiCarsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    // [HttpGet]
    // public IEnumerable<Car> GetCars()
    // {
    //     return _context.Cars.ToList();
    // }

    [HttpGet("{id}")]
    public ActionResult<Car> GetCar(int id)
    {
        var car = _context.Cars.Find(id);
        if (car == null)
        {
            return NotFound();
        }
        return car;
    }
    [HttpGet("GetCars")]
    public async Task<IActionResult> GetCars()
    {
        var cars = await _context.Cars
            .Include(c => c.Inquiries)
            .Select(c => new
            {
                c.Id,
                c.Make,
                c.Model,
                c.Year,
                c.Price,
                c.Description,
                c.ImageUrl,
                InquiryCount = c.Inquiries.Count // Get inquiry count
            })
            .ToListAsync();

        return Ok(cars);
    }

    [HttpPost("Inquire")]
    [Authorize] // Only logged-in users can inquire
    public async Task<IActionResult> InquireAboutCar(Inquiry request)
    {
        Console.WriteLine("Inquire ApiCarsController");
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get logged-in user ID
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null) return Unauthorized();

        // Check if the user is an admin
        if (user.IsAdmin) return Forbid(); // Admins cannot inquire

        var car = await _context.Cars.FindAsync(request.CarId);
        if (car == null) return NotFound("Car not found");

        var inquiry = new Inquiry
        {
            CarId = request.CarId,
            UserId = userId,
            Message = request.Message
        };

        _context.Inquiries.Add(inquiry);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Inquiry submitted successfully" });
    }

}
