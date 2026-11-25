using GymManagementSystem.Data.Context;
using GymManagementSystem.Web.ViewModels.Plans;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Web.Controllers;

public class PlansController : Controller
{
    private readonly GymDbContext _context;

    public PlansController(GymDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var today = DateTime.Today;

        var plans = await _context.Plans
            .AsNoTracking()
            .OrderBy(p => p.Id)
            .Select(p => new PlanCardViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                DurationDays = p.DurationDays,
                Price = p.Price,
                IsActive = p.IsActive,

                IsLocked = _context.Memberships.Any(m =>
                    m.PlanId == p.Id &&
                    m.EndDate >= today)
            })
            .ToListAsync();

        return View(plans);
    }
}