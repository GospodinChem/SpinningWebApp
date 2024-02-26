using System.ComponentModel.DataAnnotations;

namespace SpinningWebApp.Models
{
    public class CategoryViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
    }
}
