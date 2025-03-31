using Microsoft.AspNetCore.Mvc;

namespace WAD_WorkAndTravel.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
