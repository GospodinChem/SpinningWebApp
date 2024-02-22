using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinningWebApp.Data.Models
{
    public class Specification
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(40)]
        public string SpecName { get; set; } = null!;
        
        public ICollection<ProductSpecification> ProductSpecifications { get; set; } = null!;

    }
}
