//using Microsoft.eShopWeb.ApplicationCore.Interfaces;
//using Microsoft.eShopWeb.Infrastructure.Identity;
using KillerApp.LogicLayer.Interfaces;
using KillerApp.Presentation.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KillerApp.Presentation.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ILoginService loginService;

        public AccountController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                bool isloggedin = loginService.Login(HttpContext, model.UserName, model.Password);
            }
            // If we got this far, something failed, redisplay form
            return View(model);
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