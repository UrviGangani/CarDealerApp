using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CarDealerApp.Models;
using CarDealerApp.Models.ViewModel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace CarDealerApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager,
                              IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5103/api/Account/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<dynamic>(responseBody);
                string token = tokenResponse.Token;

                // Store token in session or cookie
                HttpContext.Session.SetString("AuthToken", token);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Remove("AuthToken");
            return RedirectToAction("Login", "Auth");
        }

        // Register GET action
        [HttpGet]
        public IActionResult Register() => View();

        // POST: /Auth/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);  // If model is invalid, return the same view
            }

            // Create a new ApplicationUser instance
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            // Create the user in the database
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Redirect to the login page after successful registration
                return RedirectToAction("Login", "Auth");
            }

            // If registration fails, display the errors
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

    }
}
