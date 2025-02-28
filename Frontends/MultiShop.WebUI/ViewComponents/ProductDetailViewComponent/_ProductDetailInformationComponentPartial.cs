using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailInformationComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
