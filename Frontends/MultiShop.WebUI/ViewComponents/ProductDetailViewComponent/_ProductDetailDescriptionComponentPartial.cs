using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailDescriptionComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
