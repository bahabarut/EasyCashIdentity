using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityPresentationLayer.ViewComponents
{
    public class _CustomerLayoutSidebarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
