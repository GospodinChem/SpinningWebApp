using Microsoft.AspNetCore.Mvc;

namespace SpinningWebApp.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
