using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SpinningWebApp.Data.Models;
namespace SpinningWebApp.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        public Category[] CreateCategories()
        {
            string fileName = "bin/Debug/net8.0/Data/Configuration/json_config/categories.json";
            string text = File.ReadAllText(fileName);
            
            Category[]? categoriesJson = JsonConvert.DeserializeObject<Category[]>(text);
            
            ArgumentNullException.ThrowIfNull(categoriesJson, nameof(categoriesJson));

            return categoriesJson;
        }
    }
}
