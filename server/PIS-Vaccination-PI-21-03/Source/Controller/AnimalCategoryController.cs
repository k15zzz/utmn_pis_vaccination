using Microsoft.AspNetCore.Mvc;
using PIS_Vaccination_PI_21_03.Source.Repository;

namespace PIS_Vaccination_PI_21_03.Source.Controller;

[ApiController]
[Route("/api/v1/[controller]/[action]")]
public class AnimalCategoryController : ControllerBase
{
    [HttpGet]
    [ActionName("list")]
    public async Task<IActionResult> List()
    {
        using (var db = new AppDbContext())
        {
            var towns = db.AnimalCategory.ToList();
            return Ok(towns);
        } 
    }
}