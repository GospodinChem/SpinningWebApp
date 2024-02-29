using SpinningWebApp.Data.Models;
using SpinningWebApp.Models;

namespace SpinningWebApp.Contracts
{
    public interface IShopService
    {
        Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync();
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string categoryName);
        Task<Category?> GetCategoryByName(string categoryName);
    }
}
