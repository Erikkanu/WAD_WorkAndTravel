using Microsoft.AspNetCore.Mvc;
using WAD_WorkAndTravel.Models;

public class MainController : Controller
{
    private readonly WAT_Context _context;

    public MainController(WAT_Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var testimonials = _context.Testimonials.ToList();
        return View(testimonials);
    }
}
