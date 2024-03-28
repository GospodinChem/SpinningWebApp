using Microsoft.EntityFrameworkCore;
using SpinningWebApp.Contracts;
using SpinningWebApp.Data;
using SpinningWebApp.Data.Models;
using SpinningWebApp.Models;
using System.Linq;

namespace SpinningWebApp.Services
{
    public class ShopService : IShopService
    {
        private readonly ApplicationDbContext dbContext;

        public ShopService(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
        {
            var categories = await dbContext.Categories
                .Include(c => c.Products)
                .OrderBy(c => c.Name)
                .ToListAsync();

            if (categories == null)
            {
                throw new ArgumentNullException("Няма налични категории.");
            }

            List<CategoryViewModel> models = new List<CategoryViewModel>();

            foreach (var category in categories)
            {
                CategoryViewModel model = new CategoryViewModel();
                model.Id = category.Id;
                model.Name = category.Name;
                model.ProductsCount = category.Products.Count;

                models.Add(model);
            }

            return models;
        }

        public async Task<CategoryViewModel> GetCategoryByNameAsync(string categoryName)
        {
            var category = await dbContext.Categories
                .FirstOrDefaultAsync(c => c.Name == categoryName);

            if (category == null)
            {
                throw new ArgumentException("Въведената категория не бе намерена.");
            }

            var viewModel = new CategoryViewModel()
            {
                Id = category.Id,
                Name = categoryName,
                ProductsCount = category.Products.Count
            };

            return viewModel;
        }

        public async Task<IEnumerable<CategoryProductsViewModel>> GetCategoryAndProductsAsync()
        {
            var categories = await dbContext.Categories
                 .Include(ca => ca.Products)
                 .OrderBy(ca => ca.Name)
                 .ToListAsync();

            if (categories == null)
            {
                throw new ArgumentNullException("Няма налични категории.");
            }

            List<CategoryProductsViewModel> models = new List<CategoryProductsViewModel>();

            foreach (var item in categories)
            {
                List<ProductViewModel> productViewModels = new List<ProductViewModel>();

                var products = await dbContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.Manufacturer)
                    .Where(p => p.Category.Name == item.Name)
                    .ToListAsync();

                foreach (var product in products)
                {
                    var productViewModel = new ProductViewModel()
                    {
                        Id = product.Id,
                        Model = product.Model,
                        Price = product.Price,
                        AvailableAmount = product.AvailableAmount,
                        Description = product.Description,
                        MainImageURL = product.MainImageURL,
                        ManufacturerName = product.Manufacturer.Name,
                        CategoryName = product.Category.Name
                    };

                    productViewModels.Add(productViewModel);
                }

                var categoryViewModel = new CategoryProductsViewModel()
                {
                    CategoryId = item.Id,
                    CategoryName = item.Name,
                    Products = productViewModels
                };

                models.Add(categoryViewModel);
            }

            return models;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsByCategoryAsync(string categoryName)
        {
            var products = await dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .Include(p => p.ProductSpecifications)
                .ThenInclude(ps => ps.Specification)
                .Include(p => p.ProductImages)
                .Where(p => p.Category.Name == categoryName)
                .OrderBy(p => p.Manufacturer.Name)
                .ToListAsync();

            if (products == null)
            {
                throw new ArgumentNullException("Няма продукти от дадената категория.");
            }

            return products
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Model = p.Model,
                    Price = p.Price,
                    AvailableAmount = p.AvailableAmount,
                    Description = p.Description,
                    MainImageURL = p.MainImageURL,
                    ManufacturerName = p.Manufacturer.Name,
                    CategoryName = p.Category.Name
                });
        }

        public async Task<IEnumerable<CrudImageViewModel>> GetProductImagesAsync(Guid productId)
        {
            var images = await dbContext.Products
                .Include(p => p.ProductImages)
                .Where(p => p.Id == productId)
                .Select(p => p.ProductImages)
                .FirstOrDefaultAsync();

            if (images == null)
            {
                throw new ArgumentNullException("Няма налични изображения.");
            }

            List<CrudImageViewModel> viewModels = new List<CrudImageViewModel>();

            foreach (var image in images)
            {
                var viewModel = new CrudImageViewModel()
                {
                    ImageURL = image.ImageURL,
                    ProductId = image.ProductId
                };
                viewModels.Add(viewModel);
            }

            return viewModels;
        }
        public async Task<IEnumerable<ProductViewModel>> GetProductsAsync(int page, int? count = null)
        {
            var products = new List<Product>();

            if (count > 0)
            {
                products = await dbContext.Products
                   .Include(p => p.Category)
                   .Include(p => p.Manufacturer)
                   .Take((int)count)
                   .ToListAsync();
            }
            else if (count == 0)
            {
                products = await dbContext.Products
                   .Include(p => p.Category)
                   .Include(p => p.Manufacturer)
                   .OrderByDescending(p => p.Id)
                   .Skip(12 * ((int)(page == 0 ? 1 : page) - 1))
                   .Take(12)
                   .ToListAsync();
            }

            if (products.Count == 0)
            {
                throw new ArgumentException("Няма налични продукти.");
            }

            List<ProductViewModel> models = [];

            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel()
                {
                    Id = product.Id,
                    Model = product.Model,
                    Price = product.Price,
                    AvailableAmount = product.AvailableAmount,
                    Description = product.Description,
                    MainImageURL = product.MainImageURL,
                    ManufacturerName = product.Manufacturer.Name,
                    CategoryName = product.Category.Name
                };

                models.Add(productViewModel);
            }

            return models;
        }

        public async Task<int> GetAllProductsCount()
        {
            var count = await dbContext.Products.CountAsync();
            return count;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsFilteredHighToLowAsync(int page, int? count = null)
        {
            var products = new List<Product>();

            products = await dbContext.Products
               .Include(p => p.Category)
               .Include(p => p.Manufacturer)
               .OrderByDescending(p => p.Price)
               .Skip(12 * ((int)(page == 0 ? 1 : page) - 1))
               .Take(12)
               .ToListAsync();


            if (products.Count == 0)
            {
                throw new ArgumentException("Няма налични продукти.");
            }

            List<ProductViewModel> models = [];

            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel()
                {
                    Id = product.Id,
                    Model = product.Model,
                    Price = product.Price,
                    AvailableAmount = product.AvailableAmount,
                    Description = product.Description,
                    MainImageURL = product.MainImageURL,
                    ManufacturerName = product.Manufacturer.Name,
                    CategoryName = product.Category.Name
                };

                models.Add(productViewModel);
            }

            return models;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsFilteredLowToHighAsync(int page, int? count = null)
        {
            var products = new List<Product>();

            products = await dbContext.Products
               .Include(p => p.Category)
               .Include(p => p.Manufacturer)
               .OrderBy(p => p.Price)
               .Skip(12 * ((int)(page == 0 ? 1 : page) - 1))
               .Take(12)
               .ToListAsync();


            if (products.Count == 0)
            {
                throw new ArgumentException("Няма налични продукти.");
            }

            List<ProductViewModel> models = [];

            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel()
                {
                    Id = product.Id,
                    Model = product.Model,
                    Price = product.Price,
                    AvailableAmount = product.AvailableAmount,
                    Description = product.Description,
                    MainImageURL = product.MainImageURL,
                    ManufacturerName = product.Manufacturer.Name,
                    CategoryName = product.Category.Name
                };

                models.Add(productViewModel);
            }

            return models;
        }
    }
}
