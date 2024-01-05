using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityPresentationLayer.Controllers
{
    public class MyAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
