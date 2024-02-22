using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SpinningWebApp.Data.Models;

namespace SpinningWebApp.Data.Configuration
{
    public class SpecificationConfiguration : IEntityTypeConfiguration<Specification>
    {
        public void Configure(EntityTypeBuilder<Specification> builder)
        {
            builder.HasData(CreateSpecifications());
        }

        public Specification[] CreateSpecifications()
        {
            string fileName = "bin/Debug/net8.0/Data/Configuration/json_config/specifications.json";
            string text = File.ReadAllText(fileName);

            Specification[]? specificationsJson = JsonConvert.DeserializeObject<Specification[]>(text);

            ArgumentNullException.ThrowIfNull(specificationsJson, nameof(specificationsJson));

            return specificationsJson;
        }
    }
}
