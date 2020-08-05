using BokingWarnet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
                                    SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginPageViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username,
                    model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Booking", "Admin");
                }

                ModelState.AddModelError(string.Empty, "Invalid Username or Password");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GantiPassword()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GantiPassword(GantiPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = await userManager.GetUserAsync(User);

                var changedPasswordUser = await userManager.ChangePasswordAsync(user,
                    model.CurrentPassword, model.PasswordBaru);

                if (changedPasswordUser.Succeeded)
                {
                    foreach (var error in changedPasswordUser.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    await signInManager.RefreshSignInAsync(user);
                    return View("KonfirmasiPassword");
                }
            }

            return View();
        }


        [HttpGet]
        public IActionResult KonfirmasiPassword()
        {
            return View();
        }

    }
}
