using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ApiCarsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ApiCarsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Car> GetCars()
    {
        return _context.Cars.ToList();
    }

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
}
