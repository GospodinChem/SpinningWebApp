using Microsoft.AspNetCore.Mvc;

namespace SpinningWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
