using Microsoft.AspNetCore.Mvc;

namespace WAD_WorkAndTravel.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
