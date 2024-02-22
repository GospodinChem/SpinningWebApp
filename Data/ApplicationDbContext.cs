using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpinningWebApp.Data.Configuration;
using SpinningWebApp.Data.Models;
using SpinningWebApp.Models.Account;

namespace SpinningWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<ProductImage> Images { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<SessionProduct> SessionProducts { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductSpecification>()
                .HasKey(ps => new
                {
                    ps.ProductId,
                    ps.SpecificationId
                });

            builder.Entity<SessionProduct>()
                .HasKey(sp => new
                {
                    sp.ProductId,
                    sp.SessionId
                });

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ManufacturerConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ImagesConfiguration());
            builder.ApplyConfiguration(new SpecificationConfiguration());
            builder.ApplyConfiguration(new ProductSpecificationConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
