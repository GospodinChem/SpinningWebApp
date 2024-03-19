using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SpinningWebApp.Contracts;
using SpinningWebApp.Data;
using SpinningWebApp.Data.Models;
using SpinningWebApp.Models;

namespace SpinningWebApp.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext dbContext;

        public AdminService(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<Guid> SaveProductAsync(CrudProductViewModel viewModel)
        {
            var manufacturer = await GetManufacturerAsync(viewModel.ManufacturerName);
            var category = await GetCategoryAsync(viewModel.CategoryName);

            if (manufacturer == null || category == null)
            {
                throw new ArgumentNullException("Производителят / катергорията не е/са невалидни.");
            }

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Model = viewModel.Model,
                Price = viewModel.Price,
                AvailableAmount = viewModel.AvailableAmount,
                Description = viewModel.Description,
                MainImageURL = viewModel.MainImageURL,
                ManufacturerId = manufacturer.Id,
                CategoryId = category.Id,
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            return product.Id;
        }

        public async Task<Category> GetCategoryAsync(string categoryName)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(ca => ca.Name == categoryName);

            if (category == null)
            {
                throw new ArgumentNullException("Категорията не бе намерена");
            }

            return category;
        }

        public async Task<Manufacturer> GetManufacturerAsync(string manufacturerName)
        {
            var manufacturer = await dbContext.Manufacturers.FirstOrDefaultAsync(m => m.Name == manufacturerName);

            if (manufacturer == null)
            {
                throw new ArgumentNullException("Производителят не бе намерен.");
            }

            return manufacturer;
        }

        public async Task<CrudProductViewModel> PrepareCrudProductViewModelAsync(string categoryName)
        {
            if (categoryName.IsNullOrEmpty())
            {
                throw new ArgumentNullException("Нужната категория не бе въведена.");
            }

            CrudProductViewModel viewModel = new CrudProductViewModel();
            viewModel.CategoryName = categoryName;

            if (categoryName != "Аксесоари")
            {
                var specifications = await dbContext.Specifications.ToListAsync()
                ?? throw new ArgumentNullException("Няма налични характеристики.");

                List<SpecificationViewModel> specificationsList = new List<SpecificationViewModel>();

                switch (categoryName)
                {
                    case "Въдици":
                        specifications = specifications
                            .Where(s =>
                            s.SpecName == "Дължина" ||
                            s.SpecName == "Брой секции" ||
                            s.SpecName == "Транспортна дължина" ||
                            s.SpecName == "Тегло" ||
                            s.SpecName == "Работен диапазон" ||
                            s.SpecName == "Вид риба").ToList();
                        break;
                    case "Макари":
                        specifications = specifications
                            .Where(s =>
                            s.SpecName == "Размер" ||
                            s.SpecName == "Тегло" ||
                            s.SpecName == "Предавателно число" ||
                            s.SpecName == "Драг" ||
                            s.SpecName == "Брой лагери" ||
                            s.SpecName == "С резервна шпула" ||
                            s.SpecName == "Вместимост на шпулата"
                            ).ToList();
                        break;
                    case "Воблери":
                        specifications = specifications
                            .Where(s =>
                            s.SpecName == "Дължина" ||
                            s.SpecName == "Дълбочина на газене" ||
                            s.SpecName == "Тегло" ||
                            s.SpecName == "Тип" ||
                            s.SpecName == "Форма" ||
                            s.SpecName == "С тракалка" ||
                            s.SpecName == "Вид риба"
                            ).ToList();
                        break;
                    case "Силикони":
                        specifications = specifications
                            .Where(s =>
                            s.SpecName == "Размер" ||
                            s.SpecName == "Тегло" ||
                            s.SpecName == "Форма" ||
                            s.SpecName == "Вкус и аромат" ||
                            s.SpecName == "UV/Glow цветове" ||
                            s.SpecName == "Окомплектовани с глава и кука" ||
                            s.SpecName == "Вид риба"
                            ).ToList();
                        break;
                    case "Джиг Глави":
                        specifications = specifications
                            .Where(s =>
                            s.SpecName == "Тегло"
                            ).ToList();
                        break;
                    case "Блесни":
                        specifications = specifications
                            .Where(s =>
                            s.SpecName == "Тегло" ||
                            s.SpecName == "UV/Glow цветове" ||
                            s.SpecName == "Вид риба"
                            ).ToList();
                        break;
                    case "Куки":
                        specifications = specifications
                            .Where(s =>
                            s.SpecName == "Размер"
                            ).ToList();
                        break;
                    case "Влакна":
                        specifications = specifications
                            .Where(s =>
                            s.SpecName == "Размер" ||
                            s.SpecName == "Дължина"
                            ).ToList();
                        break;
                }

                specificationsList = specifications.Select(s => new SpecificationViewModel()
                {
                    SpecificationName = s.SpecName
                }).ToList();

                viewModel.SpecificationViewModels = specificationsList;
            }

            return viewModel;
        }

        public async Task SaveProductSpecificationAsync(CrudProductViewModel viewModel, Guid productId)
        {
            foreach (var item in viewModel.SpecificationViewModels)
            {
                var psMappingTable = new ProductSpecification()
                {
                    ProductId = productId,
                    SpecificationId = await dbContext.Specifications
                    .Where(s => s.SpecName == item.SpecificationName)
                    .Select(s => s.Id).FirstOrDefaultAsync(),
                    SpecificationValue = item.SpecificationValue
                };

                await dbContext.ProductSpecifications.AddAsync(psMappingTable);
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<CrudProductViewModel> PrepareModelForUpdateAsync(Guid productId)
        {
            var product = await dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .Include(p => p.ProductSpecifications)
                .ThenInclude(ps => ps.Specification)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                throw new ArgumentNullException("Нужните данни не бяха намерени.");
            }

            var viewModel = new CrudProductViewModel()
            {
                Id = productId,
                ManufacturerName = product.Manufacturer.Name,
                Model = product.Model,
                Price = product.Price,
                AvailableAmount = product.AvailableAmount,
                Description = product.Description,
                MainImageURL = product.MainImageURL,
                CategoryName = product.Category.Name
            };

            if (viewModel.CategoryName != "Аксесоари")
            {
                var specs = product.ProductSpecifications;
                List<SpecificationViewModel> specViewModels = new List<SpecificationViewModel>();

                foreach (var item in specs)
                {
                    var specsViewModel = new SpecificationViewModel()
                    {
                        SpecificationName = item.Specification.SpecName,
                        SpecificationValue = item.SpecificationValue
                    };

                    specViewModels.Add(specsViewModel);
                }

                viewModel.SpecificationViewModels = specViewModels;
            }
            return viewModel;
        }

        public async Task UpdateProductAndSpecsAsync(CrudProductViewModel viewModel)
        {
            var manufacturer = await GetManufacturerAsync(viewModel.ManufacturerName);
            var category = await GetCategoryAsync(viewModel.CategoryName);


            if (manufacturer == null || category == null)
            {
                throw new ArgumentNullException("Производителят / катергорията не е/са невалидни.");
            }

            var product = new Product()
            {
                Id = viewModel.Id,
                Model = viewModel.Model,
                Price = viewModel.Price,
                AvailableAmount = viewModel.AvailableAmount,
                Description = viewModel.Description,
                MainImageURL = viewModel.MainImageURL,
                ManufacturerId = manufacturer.Id,
                CategoryId = category.Id,
            };

            dbContext.Products.Update(product);

            if (viewModel.CategoryName != "Аксесоари")
            {
                foreach (var item in viewModel.SpecificationViewModels)
                {
                    var psMappingTable = new ProductSpecification()
                    {
                        ProductId = viewModel.Id,
                        SpecificationId = await dbContext.Specifications
                        .Where(s => s.SpecName == item.SpecificationName)
                        .Select(s => s.Id).FirstOrDefaultAsync(),
                        SpecificationValue = item.SpecificationValue
                    };

                    dbContext.ProductSpecifications.Update(psMappingTable);
                }
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
