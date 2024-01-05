using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityPresentationLayer.ViewComponents
{
    public class _CustomerLayoutHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
