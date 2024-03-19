using SpinningWebApp.Data.Models;
using SpinningWebApp.Models;

namespace SpinningWebApp.Contracts
{
    public interface IAdminService
    {
        Task<CrudProductViewModel> PrepareCrudProductViewModelAsync(string categoryName);
        Task<Manufacturer> GetManufacturerAsync(string manufacturerName);   
        Task<Category> GetCategoryAsync(string categoryName);
        Task<Guid> SaveProductAsync(CrudProductViewModel viewModel);
        Task SaveProductSpecificationAsync(CrudProductViewModel viewModel, Guid productId);
        Task<CrudProductViewModel> PrepareModelForUpdateAsync(Guid productId);
        Task UpdateProductAsync(CrudProductViewModel viewModel);
    }
}
