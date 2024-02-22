using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SpinningWebApp.Data.Models;

namespace SpinningWebApp.Data.Configuration
{
    public class ImagesConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasData(CreateImages());
        }

        public ProductImage[] CreateImages()
        {
            string fileName = "bin/Debug/net8.0/Data/Configuration/json_config/images.json";
            string text = File.ReadAllText(fileName);

            ProductImage[]? imagesJson = JsonConvert.DeserializeObject<ProductImage[]>(text);

            ArgumentNullException.ThrowIfNull(imagesJson, nameof(imagesJson));

            return imagesJson;
        }
    }
}
