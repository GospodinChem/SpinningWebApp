using System.ComponentModel.DataAnnotations;

namespace SpinningWebApp.Models
{
    public class CrudProductViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Model { get; set; } = null!;

        [Required]
        public double Price { get; set; }

        [Required]
        public int ShoppingCount { get; set; } 

        [Required]
        public int AvailableAmount { get; set; }

        [Required]
        [StringLength(1500)]
        public string Description { get; set; } = null!;

        [Required]
        public string MainImageURL { get; set; } = null!;

        [Required]
        public string ManufacturerName { get; set; } = null!;

        [Required]
        public string CategoryName { get; set; } = null!;

        [Required]
        public List<SpecificationViewModel> SpecificationViewModels { get; set; } = null!;
    }
}
