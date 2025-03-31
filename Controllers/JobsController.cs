using AspNetCoreEFCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Controllers
{
    public class JobsController : Controller
    {
        private readonly WAT_Context _context;

        public JobsController(WAT_Context context)
        {
            _context = context;
        }

        // Updated Index method to support filtering
        public async Task<IActionResult> Index(string keyword, string state, string category)
        {
            var jobs = _context.Jobs.AsQueryable();

            // Apply filters dynamically
            if (!string.IsNullOrEmpty(keyword))
            {
                jobs = jobs.Where(j => j.Title.Contains(keyword) || j.Company.Contains(keyword));
            }

            if (!string.IsNullOrEmpty(state))
            {
                jobs = jobs.Where(j => j.State == state);
            }

            if (!string.IsNullOrEmpty(category))
            {
                jobs = jobs.Where(j => j.Category == category);
            }

            return View(await jobs.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .FirstOrDefaultAsync(m => m.JobID == id);

            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }
    }
}
