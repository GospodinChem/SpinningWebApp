using SpinningWebApp.Data.Models;
using SpinningWebApp.Models;

namespace SpinningWebApp.Contracts
{
    public interface IAdminService
    {
        Task<AddProductViewModel> PrepareAddProductViewModelAsync(string categoryName);
        Task<Manufacturer> GetManufacturerAsync(string manufacturerName);   
        Task<Category> GetCategoryAsync(string categoryName);
        Task<Guid> SaveProductAsync(AddProductViewModel viewModel);
        Task SaveProductSpecificationAsync(AddProductViewModel viewModel, Guid productId);
    }
}
