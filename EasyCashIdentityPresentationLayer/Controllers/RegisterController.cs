using EasyCashIdentityBusinessLayer.ValidationRules.AppUserValidationRules;
using EasyCashIdentityDTOLayer.DTOs.AppUserDTOs;
using EasyCashIdentityEntityLayer.Concrete;
using FluentValidation.Results;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
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
            AppUserRegisterValidator validator = new AppUserRegisterValidator();
            ValidationResult resultVal = validator.Validate(model);
            if (resultVal.IsValid)
            {
                if (model.password == model.confirmpassword)
                {
                    Random random = new Random();
                    int code = random.Next(100000, 1000000);
                    AppUser newUser = new AppUser()
                    {
                        Name = model.name,
                        SurName = model.surname,
                        UserName = model.username,
                        Email = model.email,
                        PhoneNumber = model.confirmpassword,
                        City = "Ankara",
                        District = "Altındağ",
                        ConfirmCode = code
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
                        MimeMessage mimeMessage = new MimeMessage();
                        MailboxAddress fromMailbox = new MailboxAddress("Easy Cash Admin", "sendermail");
                        MailboxAddress toMailbox = new MailboxAddress("User", model.email);

                        mimeMessage.From.Add(fromMailbox);
                        mimeMessage.To.Add(toMailbox);

                        BodyBuilder bodyBuilder = new BodyBuilder();
                        bodyBuilder.TextBody = "Kayıt İşleminizi Tamamlamak İçin Onay Kodunuz : " + code;
                        mimeMessage.Body = bodyBuilder.ToMessageBody();
                        mimeMessage.Subject = "Easy Cash Onay Kodu";

                        SmtpClient client = new SmtpClient();
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("sendermail", "app security key");
                        client.Send(mimeMessage);
                        client.Disconnect(true);
                        TempData["registerUserMail"] = model.email;
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
                ModelState.AddModelError("confirmpassword", "Şifreler Uyuşmuyor");
                return View(model);
            }
            foreach (var res in resultVal.Errors)
            {
                ModelState.AddModelError(res.PropertyName, res.ErrorMessage);
            }
            return View(model);
        }
    }
}
