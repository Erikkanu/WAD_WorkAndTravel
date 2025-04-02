using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WAD_WorkAndTravel.Services;
using WAD_WorkAndTravel.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;


namespace WAD_WorkAndTravel.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthService _authService;


        public LoginController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            var user = _authService.AuthenticateUser(username, password);
            if (user != null)
            {
                // 🔹 Create user claims
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.username),
            new Claim(ClaimTypes.NameIdentifier, user.id.ToString())
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // 🔹 Sign in user
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return RedirectToAction("Index", "Registration"); // Redirect to home page
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
