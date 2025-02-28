using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListPaginationFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
