using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WorkloadApp.Data;

namespace WorkloadApp.Controllers
{
    public class CitiesController : Controller
    {
        private readonly AppDbContext _context;
        
        public CitiesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allCities = await _context.Cities.ToListAsync();
            return View();
        }
    }
}
