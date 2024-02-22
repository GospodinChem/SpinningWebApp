using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SpinningWebApp.Data.Models;

namespace SpinningWebApp.Data.Configuration
{
    public class ProductSpecificationConfiguration : IEntityTypeConfiguration<ProductSpecification>
    {
        public void Configure(EntityTypeBuilder<ProductSpecification> builder)
        {
            builder.HasData(CreatePS());
        }

        public ProductSpecification[] CreatePS()
        {
            string fileName = "bin/Debug/net8.0/Data/Configuration/json_config/product_specifications.json";
            string text = File.ReadAllText(fileName);

            ProductSpecification[]? specsJson = JsonConvert.DeserializeObject<ProductSpecification[]>(text);

            ArgumentNullException.ThrowIfNull(specsJson, nameof(specsJson));

            return specsJson;
        }
    }
}
