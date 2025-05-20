using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using WAD_WorkAndTravel.Models;
using WAD_WorkAndTravel.Services;
using Microsoft.AspNetCore.Authorization;

namespace WAD_WorkAndTravel.Controllers
{
    public class MainController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MainController(ITestimonialService testimonialService, IWebHostEnvironment webHostEnvironment)
        {
            _testimonialService = testimonialService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Testimonials
        public IActionResult Index()
        {
            var testimonials = _testimonialService.GetAllTestimonials();
            return View(testimonials);
        }

        // GET: Testimonials/Details/5
        public IActionResult Details(int id)
        {
            var testimonial = _testimonialService.GetTestimonialById(id);
            if (testimonial == null)
            {
                return NotFound();
            }
            return View(testimonial);
        }

        // GET: Testimonials/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Testimonials/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create(Testimonial testimonial, Microsoft.AspNetCore.Http.IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                // Handle image upload
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/testimonials");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Create directory if it doesn't exist
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(fileStream);
                    }

                    testimonial.imagePath = "/images/testimonials/" + uniqueFileName;
                }
                else
                {
                    // Set a default image if none provided
                    testimonial.imagePath = "/images/testimonials/default-profile.jpg";
                }

                _testimonialService.CreateTestimonial(testimonial);
                return RedirectToAction(nameof(Index));
            }
            return View(testimonial);
        }

        // GET: Testimonials/Edit/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id)
        {
            var testimonial = _testimonialService.GetTestimonialById(id);
            if (testimonial == null)
            {
                return NotFound();
            }
            return View(testimonial);
        }

        // POST: Testimonials/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id, Testimonial testimonial, Microsoft.AspNetCore.Http.IFormFile ImageFile)
        {
            if (id != testimonial.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Handle image upload if a new image is provided
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    // Delete old image if it exists and is not the default
                    if (!string.IsNullOrEmpty(testimonial.imagePath) &&
                        !testimonial.imagePath.Contains("default-profile.jpg") &&
                        System.IO.File.Exists(_webHostEnvironment.WebRootPath + testimonial.imagePath))
                    {
                        System.IO.File.Delete(_webHostEnvironment.WebRootPath + testimonial.imagePath);
                    }

                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/testimonials");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Create directory if it doesn't exist
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(fileStream);
                    }

                    testimonial.imagePath = "/images/testimonials/" + uniqueFileName;
                }

                _testimonialService.UpdateTestimonial(testimonial);
                return RedirectToAction(nameof(Index));
            }
            return View(testimonial);
        }

        // GET: Testimonials/Delete/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            var testimonial = _testimonialService.GetTestimonialById(id);
            if (testimonial == null)
            {
                return NotFound();
            }
            return View(testimonial);
        }

        // POST: Testimonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteConfirmed(int id)
        {
            var testimonial = _testimonialService.GetTestimonialById(id);

            if (testimonial != null)
            {
                // Delete the image file if it exists and is not the default
                if (!string.IsNullOrEmpty(testimonial.imagePath) &&
                    !testimonial.imagePath.Contains("default-profile.jpg") &&
                    System.IO.File.Exists(_webHostEnvironment.WebRootPath + testimonial.imagePath))
                {
                    System.IO.File.Delete(_webHostEnvironment.WebRootPath + testimonial.imagePath);
                }

                _testimonialService.DeleteTestimonial(testimonial);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}