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
            if (!ModelState.IsValid)
            {
                return View("Index", form); // Return form with validation errors if invalid
            }

            _context.RegistrationForms.Add(form);
            _context.SaveChanges();

            ViewBag.SuccessMessage = "Your application has been successfully submitted!";

            return View("Index", new RegistrationForm()); // Clear form by passing a new instance
        }
    }
}
