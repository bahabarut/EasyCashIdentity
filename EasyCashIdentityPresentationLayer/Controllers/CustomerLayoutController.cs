using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityPresentationLayer.Controllers
{
    public class CustomerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
