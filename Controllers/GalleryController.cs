using Microsoft.AspNetCore.Mvc;
using WAD_WorkAndTravel.Models;

public class GalleryController : Controller
{
    private readonly WAT_Context _context;

    public GalleryController(WAT_Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var galleryPosts = _context.GalleryPosts.ToList();
        return View(galleryPosts);
    }
}
