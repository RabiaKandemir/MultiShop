using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailFeatureComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
