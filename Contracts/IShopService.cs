using SpinningWebApp.Data.Models;
using SpinningWebApp.Models;

namespace SpinningWebApp.Contracts
{
    public interface IShopService
    {
        Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync();
        Task<IEnumerable<ProductViewModel>> GetProductsByCategoryAsync(string categoryName);
        Task<CategoryViewModel> GetCategoryByNameAsync(string categoryName);
        Task<IEnumerable<ProductViewModel>> GetProductsAsync(int? count = null);
        Task<IEnumerable<CrudImageViewModel>> GetProductImagesAsync(Guid productId);
        Task<IEnumerable<CategoryProductsViewModel>> GetCategoryAndProductsAsync();
    }
}
