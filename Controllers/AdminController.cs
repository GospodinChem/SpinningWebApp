﻿using Microsoft.AspNetCore.Mvc;
using SpinningWebApp.Contracts;
using SpinningWebApp.Data.Models;
using SpinningWebApp.Models;

namespace SpinningWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IShopService shopService;
        private readonly IAdminService adminService;

        public AdminController(IShopService _shopService, IAdminService _adminService)
        {
            this.shopService = _shopService;
            this.adminService = _adminService;
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
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct(string categoryName)
        {
            if (categoryName == null)
                return RedirectToAction("Dashboard", "Admin");

            try
            {
                var viewModel = await adminService.PrepareCrudProductViewModelAsync(categoryName);
                return View(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(CrudProductViewModel viewModel)
        {
            if (viewModel == null)
            {
                return RedirectToAction("Dashboard", "Admin");
            }

            try
            {
                var productId = await adminService.SaveProductAsync(viewModel);
                await adminService.SaveProductSpecificationAsync(viewModel, productId);
                return RedirectToAction("Dashboard", "Admin");

            }
            catch (Exception)
            {
                return RedirectToAction("AddProduct", "Admin");
            }
        }

        [HttpGet]
        public async Task<IActionResult> RedactProduct(Guid productId)
        {
            try
            {
                var viewModel = await adminService.PrepareModelForUpdateAsync(productId);
                return View(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
        }
        [HttpPost]
        public async Task<IActionResult> RedactProduct(CrudProductViewModel viewModel)
        {
            if (viewModel == null)
            {
                return RedirectToAction("Dashboard", "Admin");
            }

            try
            {
                await adminService.UpdateProductAsync(viewModel);
                return RedirectToAction("DashBoard", "Admin");
            }
            catch (Exception)
            {
                return RedirectToAction("DashBoard", "Admin");
            }
        }
    }
}
