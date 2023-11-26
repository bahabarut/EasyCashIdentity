using EasyCashIdentityDTOLayer.DTOs.AppUserDTOs;
using EasyCashIdentityEntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace EasyCashIdentityPresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser newUser = new AppUser()
                {
                    Name = model.name,
                    SurName = model.surname,
                    UserName = model.username,
                    Email = model.email,
                    PhoneNumber = model.confirmpassword,
                    City = "Ankara",
                    District = "Altındağ"
                };
                if (model.image != null)
                {
                    var extension = Path.GetExtension(model.image.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var resource = Directory.GetCurrentDirectory();
                    var location = resource + "/wwwroot/userImages/" + imageName;
                    var stream = new FileStream(location, FileMode.Create);
                    model.image.CopyTo(stream);
                    newUser.ImageUrl = imageName;
                }
                else
                {
                    newUser.ImageUrl = "defaultProfile.png";
                }
                var result = await _userManager.CreateAsync(newUser, model.confirmpassword);
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(model);
                }
            }
            return View(model);
        }
    }
}
