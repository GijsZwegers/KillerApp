//using Microsoft.eShopWeb.ApplicationCore.Interfaces;
//using Microsoft.eShopWeb.Infrastructure.Identity;
using KillerApp.LogicLayer.Interfaces;
using KillerApp.Presentation.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace KillerApp.Presentation.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly ILoginService loginService;

        public AccountController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [Route("Login"), Authorize]
        public IActionResult Login()
        {
            return View();
        }

        [Route(""), Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, AllowAnonymous]
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

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                bool isregistred = loginService.Register(HttpContext, model.UserName, model.Password, model.ConfirmPassword);
            }
            var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });
            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}