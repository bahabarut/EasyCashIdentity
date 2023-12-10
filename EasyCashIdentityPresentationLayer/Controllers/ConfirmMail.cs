using EasyCashIdentityEntityLayer.Concrete;
using EasyCashIdentityPresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityPresentationLayer.Controllers
{
    public class ConfirmMail : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ConfirmMail(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var mail = TempData["registerUserMail"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.mail);
            if (user.ConfirmCode == model.confirmCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
