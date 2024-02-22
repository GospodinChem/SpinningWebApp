using System.ComponentModel.DataAnnotations;

namespace SpinningWebApp.Data.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = null!;
    }
}
