using Microsoft.AspNetCore.Mvc;
using SpinningWebApp.Contracts;
using SpinningWebApp.Models;

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
        public async Task<IActionResult> Index(string? categoryName = null, string? sortType = null)
        {
            var categories = await shopService.GetCategoriesAsync();

            if (categoryName == null)
            {
                categoryName = "Въдици";
            }

            if (categories != null)
            {
                ViewBag.Categories = categories;
                CategoryViewModel category = new();

                try
                {
                    category = await shopService.GetCategoryByNameAsync(categoryName);
                    ViewBag.Products = await shopService.GetProductsByCategoryAsync(categoryName);
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "Home");
                }

                if (category != null)
                {
                    return View("Index", category);
                }

            }
            return RedirectToAction("Index", "Home");
        }
    }
}

