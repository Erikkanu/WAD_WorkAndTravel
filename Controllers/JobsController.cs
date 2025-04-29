using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WAD_WorkAndTravel.Models;
using WAD_WorkAndTravel.Services;

namespace WAD_WorkAndTravel.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        // GET: Jobs
        public IActionResult Index(string keyword, string state, string category)
        {
            var jobs = _jobService.GetAllJobs().ToList();

            // Apply filters
            if (!string.IsNullOrEmpty(keyword))
            {
                jobs = jobs.Where(j => j.Title.Contains(keyword) || j.Company.Contains(keyword)).ToList();
            }

            if (!string.IsNullOrEmpty(state))
            {
                jobs = jobs.Where(j => j.State == state).ToList();
            }

            if (!string.IsNullOrEmpty(category))
            {
                jobs = jobs.Where(j => j.Category == category).ToList();
            }

            return View(jobs);
        }

        // GET: Jobs/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = _jobService.GetJobById(id.Value);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                _jobService.CreateJob(job);
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // GET: Jobs/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var job = _jobService.GetJobById(id.Value);
            if (job == null) return NotFound();

            return View(job);
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Job job)
        {
            if (id != job.JobID) return NotFound();

            if (ModelState.IsValid)
            {
                var existingJob = _jobService.GetJobById(id);
                if (existingJob == null)
                {
                    return NotFound();
                }

                _jobService.UpdateJob(job);
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var job = _jobService.GetJobById(id.Value);
            if (job == null) return NotFound();

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var job = _jobService.GetJobById(id);
            if (job != null)
            {
                _jobService.DeleteJob(job);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}