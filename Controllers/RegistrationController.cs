using AspNetCoreEFCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly WAT_Context _context;

        public RegistrationController(WAT_Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new RegistrationForm());  // Pass an empty model
        }

        [HttpPost]
        public IActionResult SubmitForm(RegistrationForm form)
        {
            if (ModelState.IsValid)
            {
                _context.Registrations.Add(form);
                _context.SaveChanges();
                return RedirectToAction("Success");  // Redirect to a success page
            }
            return View("Index", form);  // If invalid, return to form
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
