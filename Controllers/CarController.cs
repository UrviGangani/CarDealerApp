using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CarDealerApp.Models; 
using CarDealerApp.Data;   
using CarDealerApp.Models.ViewModel; 


public class CarController : Controller
{
    private readonly ApplicationDbContext _context;

    public CarController(ApplicationDbContext context)
    {
        _context = context;
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
}
