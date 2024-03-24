using Microsoft.AspNetCore.Mvc;
using SpinningWebApp.Contracts;
using SpinningWebApp.Models;

namespace SpinningWebApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService shopService;
        private readonly IAdminService adminService;

        public ShopController(IShopService _shopService, IAdminService _adminService)
        {
            this.shopService = _shopService;
            this.adminService = _adminService;
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

        [HttpGet]
        public async Task<IActionResult> SingleProduct(Guid productId)
        {
            try
            {
                var viewModel = await adminService.PrepareModelWithSpecsNameValueAsync(productId);
                return View(viewModel);
            }
            catch(Exception)
            {
                return RedirectToAction("Index", "Shop");
            }
        }

        [HttpGet]
        public IActionResult Cart(Guid productId, int productCount)
        {
            return View();
        }
    }
}

