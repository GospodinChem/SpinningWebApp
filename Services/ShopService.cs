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
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Name == categoryName);
            
            return category;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string categoryName)
        {
            var products = await dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .Where(p => p.Category.Name == categoryName)
                .ToListAsync();

            return products;
        }
    }
}
