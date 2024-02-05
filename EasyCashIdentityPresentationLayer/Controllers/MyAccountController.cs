using EasyCashIdentityDTOLayer.DTOs.AppUserDTOs;
using EasyCashIdentityEntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityPresentationLayer.Controllers
{
    public class MyAccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditDTO editUser = new AppUserEditDTO()
            {
                Name = user.Name,
                SurName = user.SurName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                District = user.District
            };
            return View(editUser);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDTO model)
        {
            if (model.Password == model.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.City = model.City;
                user.District = model.District;
                user.PasswordHash = model.Password != null ? _userManager.PasswordHasher.HashPassword(user, model.Password) : user.PasswordHash;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Login");
            }
            else
            {
                ModelState.AddModelError("ConfirmPassword", "Şifreler Uyuşmuyor");
            }
            return View();
        }
    }
}
