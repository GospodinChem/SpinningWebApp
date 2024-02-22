using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SpinningWebApp.Data.Models;

namespace SpinningWebApp.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(CreateProducts());
        }

        public Product[] CreateProducts()
        {
            string fileName = "bin/Debug/net8.0/Data/Configuration/json_config/products.json";
            string text = File.ReadAllText(fileName);

            Product[]? productsJson = JsonConvert.DeserializeObject<Product[]>(text);

            ArgumentNullException.ThrowIfNull(productsJson, nameof(productsJson));

            return productsJson;
        }
    }
}
