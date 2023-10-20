using Microsoft.AspNetCore.Mvc;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]")]
public class TownController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> List()
    {
        using (AppDbContext db = new AppDbContext())
        {
            var towns = db.Towns.ToList();
            return Ok(towns);
        }
    }
}