using Microsoft.AspNetCore.Mvc;
using SpinningWebApp.Contracts;

namespace SpinningWebApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService shopService;

        public ShopController(IShopService _shopService)
        {
            this.shopService = _shopService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await shopService.GetCategoriesAsync();

            if (model != null)
            {
                return View("Index", model);
            }
            return View("Index", "Home");
        }
    }
}
