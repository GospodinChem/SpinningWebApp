using Microsoft.EntityFrameworkCore;
using SpinningWebApp.Contracts;
using SpinningWebApp.Data;
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
            var categories = await dbContext.Categories.ToListAsync();

            return categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                });
        }
    }
}
