//using Microsoft.eShopWeb.ApplicationCore.Interfaces;
//using Microsoft.eShopWeb.Infrastructure.Identity;
using KillerApp.Presentation.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.eShopWeb.Web.ViewModels.Account;
using System;
using System.Threading.Tasks;

namespace KillerApp.Presentation.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //private readonly UserManager<ApplicationUser> _userManager;

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //        var result = await _userManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            await _signInManager.SignInAsync(user, isPersistent: false);
        //            return RedirectToLocal(returnUrl);
        //        }
        //        AddErrors(result);
        //    }
        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}
    }
}