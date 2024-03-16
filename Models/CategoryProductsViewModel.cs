using System.ComponentModel.DataAnnotations;

namespace SpinningWebApp.Models
{
    public class CategoryProductsViewModel
    {
        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; } = null!;

        public ICollection<ProductViewModel> Products { get; set; } = null!;
    }
}
