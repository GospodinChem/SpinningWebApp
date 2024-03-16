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

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            try
            {
                var viewModels = await shopService.GetCategoryAndProductsAsync();

                if (viewModels != null)
                {
                    return View(viewModels);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AddProduct(string categoryName)
        {

        }
    }
}
