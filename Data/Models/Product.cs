using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinningWebApp.Data.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(35)]
        public string Model { get; set; } = null!;

        [Required]
        public double Price { get; set; }

        [Required]
        public int AvailableAmount { get; set; }

        [Required]
        [StringLength(1500)]
        public string Description { get; set; } = null!;

        [ForeignKey("Manufacturer")]
        public Guid ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; } = null!;

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<ProductImage> ProductImages { get; set; } = null!;

        public ICollection<ProductSpecification> ProductAttributes { get; set; } = null!;

        public ICollection<SessionProduct> SessionProducts { get; set; } = null!;

    }
}
