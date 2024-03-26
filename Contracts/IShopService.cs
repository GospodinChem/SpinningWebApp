using SpinningWebApp.Data.Models;
using SpinningWebApp.Models;

namespace SpinningWebApp.Contracts
{
    public interface IShopService
    {
        Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync();
        Task<IEnumerable<ProductViewModel>> GetProductsByCategoryAsync(string categoryName);
        Task<CategoryViewModel> GetCategoryByNameAsync(string categoryName);
        Task<IEnumerable<CategoryProductsViewModel>> GetCategoryAndProductsAsync();
        Task<IEnumerable<CrudImageViewModel>> GetProductImagesAsync(Guid productId);
        Task<IEnumerable<>> Get
    }
}
