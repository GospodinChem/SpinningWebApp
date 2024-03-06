using Microsoft.AspNetCore.Mvc;

namespace SpinningWebApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
