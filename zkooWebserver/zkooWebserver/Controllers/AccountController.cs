using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zkooWebserver.Models;
using zkooWebserver.ViewModels;

namespace zkooWebserver.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Doctor> SignInManager;
        private readonly UserManager<Doctor> UserManager;
        public AccountController(SignInManager<Doctor> signInManager, UserManager<Doctor> userManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }

        public IActionResult Login() => View();
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded) {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Email or password is invalid");
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Doctor doctor = new()
            {
                Name = model.Name,
                Email = model.Email,
                UserName = model.Email
            };

            var result = await UserManager.CreateAsync(doctor, model.Password);

            if (result.Succeeded) 
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }
    }
}
