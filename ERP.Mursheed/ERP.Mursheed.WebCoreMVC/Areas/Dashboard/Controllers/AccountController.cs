using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Mursheed.Entities.Shared;
using ERP.Mursheed.Utility;
using ERP.Mursheed.WebCoreMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Mursheed.WebCoreMVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [AllowAnonymous]
    [Route("Dashboard/{action}")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 RoleManager<ApplicationRole> roleManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                ModelState.AddModelError("", ResultConst.UserNull);
                return View(model);
            }

            if (user.Status == false)
            {
                ModelState.AddModelError("", ResultConst.Blocked);

                return RedirectToAction("AccessDenied");
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user,
                model.Password,
                model.RememberMe,
                true);

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", ResultConst.LockedOut);
                return View(model);
            }
            if (signInResult.Succeeded)
            {
                if (Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", ResultConst.UsernameorPassWrong);
            return View(model);


        }

        #region logout
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("login");
        }

        #endregion

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}