using Microsoft.AspNetCore.Mvc;
using SpinningWebApp.Contracts;

namespace SpinningWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IShopService shopService;

        public AdminController(IShopService shopService)
        {
            this.shopService = shopService;
        }

        public async Task<IActionResult> Dashboard()
        {
            var categories = await shopService.GetCategoriesAndProductsAsync();
            return View(categories);
        }
    }
}
