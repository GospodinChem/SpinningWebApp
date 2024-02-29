using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpinningWebApp.Contracts;
using SpinningWebApp.Data.Models;
using SpinningWebApp.Models;
using System.Diagnostics;
namespace SpinningWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShopService shopService;


        public HomeController(ILogger<HomeController> logger, IShopService _shopService)
        {
            _logger = logger;
            this.shopService = _shopService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await shopService.GetCategoriesAsync();

            if (categories != null)
            {
                return View(categories);
            }

            return View("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
