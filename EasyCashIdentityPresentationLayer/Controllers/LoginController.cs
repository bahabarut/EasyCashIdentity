using EasyCashIdentityEntityLayer.Concrete;
using EasyCashIdentityPresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityPresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            // 4 parametre alır username, pass, şifremi hatırla alanı, db de Access Failed Count alanı 5 kere yanlış girerse kilitlenir hesap
            var result = await _signInManager.PasswordSignInAsync(model.username, model.password, false, true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.username);
                if (user.EmailConfirmed == true)
                {
                    return RedirectToAction("Index", "MyAccount");
                }
            }
            return View();
        }
    }
}
