using CRUDApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRUDApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(UserSignup userdetails)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = userdetails.Name, Email = userdetails.Email };
                var result = await userManager.CreateAsync(user, password: userdetails.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: true);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }

            return View(userdetails);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserSignin userdetails)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userdetails.Email);
                var result = await signInManager.PasswordSignInAsync(user.UserName, userdetails.Password, true, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }

            return View(userdetails);
        }
    }
}
