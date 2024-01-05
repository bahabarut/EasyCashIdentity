using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityPresentationLayer.ViewComponents
{
    public class _CustomerLayoutTopbarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
