using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
