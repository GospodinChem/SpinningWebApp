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
        public async Task<IActionResult> Index(string? categoryName = null)
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
        public async Task<IActionResult> Index2(int id)
        {
            try
            {
                ViewBag.Categories = await shopService.GetCategoriesAsync();

                var model = await shopService.GetProductsAsync(id, 0);
                var count = await shopService.GetAllProductsCount();

                TempData["pages"] = count % 9 == 0 ? count / 9 : (count / 9) + 1; ;
                TempData["curr"] = id == 0 ? 1 : id;

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> FilterHighToLow(int id)
        {
            try
            {
                ViewBag.Categories = await shopService.GetCategoriesAsync();

                var model = await shopService.GetProductsFilteredHighToLowAsync(id, 0);
                var count = await shopService.GetAllProductsCount();

                TempData["pages"] = count % 9 == 0 ? count / 9 : (count / 9) + 1; ;
                TempData["curr"] = id == 0 ? 1 : id;

                return View("Index2", model);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> FilterLowToHigh(int id)
        {
            
                ViewBag.Categories = await shopService.GetCategoriesAsync();

                var model = await shopService.GetProductsFilteredLowToHighAsync(id, 0);
                var count = await shopService.GetAllProductsCount();

                TempData["pages"] = count % 9 == 0 ? count / 9 : (count / 9) + 1; ;
                TempData["curr"] = id == 0 ? 1 : id;

                return View("Index2", model);
        }

        [HttpGet]
        public async Task<IActionResult> SingleProduct(Guid productId)
        {
            try
            {
                var viewModel = await adminService.PrepareModelWithSpecsNameValueAsync(productId);
                ViewBag.Images = await shopService.GetProductImagesAsync(productId);
                ViewBag.Suggested = await shopService.GetProductsAsync(0, 4);

                return View(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Shop");
            }
        }

        [HttpGet]
        public IActionResult Cart(Guid productId, int? productCount)
        {
            return View();  
        }
    }
}

