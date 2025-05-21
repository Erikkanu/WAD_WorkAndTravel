using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WAD_WorkAndTravel.Models;
using WAD_WorkAndTravel.Services;

namespace WAD_WorkAndTravel.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IGalleryPostService _galleryService;

        public GalleryController(IGalleryPostService galleryService)
        {
            _galleryService = galleryService;
        }

        // GET: Gallery
        public IActionResult Index()
        {
            var galleryPosts = _galleryService.GetAllGalleryPosts();
            return View(galleryPosts);
        }

        // GET: Gallery/Details/5
        public IActionResult Details(int id)
        {
            var galleryPost = _galleryService.GetGalleryPostById(id);
            if (galleryPost == null)
            {
                return NotFound();
            }
            return View(galleryPost);
        }

        // GET: Gallery/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gallery/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(GalleryPost galleryPost)
        {
            if (ModelState.IsValid)
            {
                _galleryService.CreateGalleryPost(galleryPost);
                return RedirectToAction(nameof(Index));
            }
            return View(galleryPost);
        }

        // GET: Gallery/Edit/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id)
        {
            var galleryPost = _galleryService.GetGalleryPostById(id);
            if (galleryPost == null)
            {
                return NotFound();
            }
            return View(galleryPost);
        }

        // POST: Gallery/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id, GalleryPost galleryPost)
        {
            if (id != galleryPost.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _galleryService.UpdateGalleryPost(galleryPost);
                return RedirectToAction(nameof(Index));
            }
            return View(galleryPost);
        }

        // GET: Gallery/Delete/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            var galleryPost = _galleryService.GetGalleryPostById(id);
            if (galleryPost == null)
            {
                return NotFound();
            }
            return View(galleryPost);
        }

        // POST: Gallery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteConfirmed(int id)
        {
            var galleryPost = _galleryService.GetGalleryPostById(id);
            if (galleryPost == null)
            {
                return NotFound();
            }

            _galleryService.DeleteGalleryPost(galleryPost);
            return RedirectToAction(nameof(Index));
        }

    }
}