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
            try
            {
                var categories = await shopService.GetCategoriesAsync();

                if (categoryName == null)
                {
                    categoryName = "Въдици";
                }

                if (categories != null)
                {
                    ViewBag.Categories = categories;

                    var category = await shopService.GetCategoryByName(categoryName);

                    if (category != null)
                    {
                        return View("Index", category);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

