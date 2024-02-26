using SpinningWebApp.Models;

namespace SpinningWebApp.Contracts
{
    public interface IShopService
    {
        Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync();
    }
}
