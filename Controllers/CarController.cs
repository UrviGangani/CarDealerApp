using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CarDealerApp.Models; 
using CarDealerApp.Data;   
using CarDealerApp.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;


public class CarController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public CarController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var cars = _context.Cars.ToList();
        return View(cars);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Car car)
    {
        if (ModelState.IsValid)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(car);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Inquire(Inquiry model)
    {
        Console.WriteLine("Inquire");
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null) return Unauthorized();
        if (user.IsAdmin) return Forbid(); // Admins cannot inquire

        var car = await _context.Cars.FindAsync(model.CarId);
        if (car == null) return NotFound();

        var inquiry = new Inquiry
        {
            CarId = model.CarId,
            UserId = userId,
            Message = model.Message
        };

        _context.Inquiries.Add(inquiry);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

}
