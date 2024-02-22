using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinningWebApp.Data.Models
{
    public class ProductSpecification
    {
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [ForeignKey("Specification")]
        public Guid SpecificationId { get; set; }
        public Specification Specification { get; set; } = null!;

        [Required]
        public string SpecificationValue { get; set; } = null!;

    }
}
