using Microsoft.EntityFrameworkCore;
using SpinningWebApp.Contracts;
using SpinningWebApp.Data;
using SpinningWebApp.Data.Models;
using SpinningWebApp.Models;

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

        public async Task<Category?> GetCategoryByName(string categoryName)
        {
            var category = await dbContext.Categories

                .FirstOrDefaultAsync(c => c.Name == categoryName);

            if (category == null)
            {
                throw new ArgumentException("Въведената категория не бе намерена.");
            }

            if (category != null)
            {
                category.Products = (ICollection<Product>)await GetProductsByCategoryAsync(categoryName);
            }

            return category;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAndProductsAsync()
        {
            var categories = await dbContext.Categories.Include(ca => ca.Products).ToListAsync();

            if (categories == null)
            {
                throw new ArgumentException("Въведената категория не бе намерена.");
            }

            if (categories != null)
            {
                for (int i = 0; i < categories.Count; i++)
                {
                    if (categories[i].Products != null)
                    {
                        categories[i].Products = (ICollection<Product>)await GetProductsByCategoryAsync(categories[i].Name);
                    }
                }
            }

            return categories;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string categoryName)
        {
            var products = await dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .Include(p => p.ProductSpecifications)
                .Include(p => p.ProductImages)
                .Where(p => p.Category.Name == categoryName)
                .OrderBy(p => p.Manufacturer.Name)
                .ToListAsync();

            if (products == null)
            {
                throw new ArgumentNullException("Няма продукти от дадената категория.");
            }

            return products;
        }
    }
}
