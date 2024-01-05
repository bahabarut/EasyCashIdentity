using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityPresentationLayer.Controllers
{
    public class MyProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
