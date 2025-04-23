using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Images.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
