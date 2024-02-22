using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SpinningWebApp.Data.Models;

namespace SpinningWebApp.Data.Configuration
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasData(CreateManufacturers());
        }

        public Manufacturer[] CreateManufacturers()
        {
            string fileName = "bin/Debug/net8.0/Data/Configuration/json_config/manufacturers.json";
            string text = File.ReadAllText(fileName);

            Manufacturer[]? manufaturersJson = JsonConvert.DeserializeObject<Manufacturer[]>(text);

            ArgumentNullException.ThrowIfNull(manufaturersJson, nameof(manufaturersJson));

            return manufaturersJson;
        }
    }
}
