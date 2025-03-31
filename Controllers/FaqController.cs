using Microsoft.AspNetCore.Mvc;

namespace WAD_WorkAndTravel.Controllers
{
    public class FaqController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
