using SpinningWebApp.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpinningWebApp.Models
{
    public class ProductViewModel
    {
        [Required]
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

        [Required]
        public string ManufacturerName { get; set; } = null!;

        [Required]
        public string CategoryName { get; set; } = null!;
    }
}
