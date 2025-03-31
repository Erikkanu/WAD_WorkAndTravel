using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Controllers
{
    public class TicketsController : Controller
    {
        private readonly WAT_Context _context;

        public TicketsController(WAT_Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Handles the flight search
        public async Task<IActionResult> Search(string origin, string destination, DateOnly? departure, DateOnly? returnDate)
        {
            var query = _context.Tickets.AsQueryable();

            if (!string.IsNullOrEmpty(origin))
            {
                query = query.Where(t => t.DepCity.Contains(origin) || t.DepAirport.Contains(origin));
            }

            if (!string.IsNullOrEmpty(destination))
            {
                query = query.Where(t => t.ArrCity.Contains(destination) || t.ArrAirport.Contains(destination));
            }

            if (departure.HasValue)
            {
                query = query.Where(t => t.DepDate == departure.Value);
            }

            if (returnDate.HasValue)
            {
                query = query.Where(t => t.ArrDate == returnDate.Value);
            }

            var ticket = await query.ToListAsync();
            return View("SearchResults", ticket);
        }
    }
}
