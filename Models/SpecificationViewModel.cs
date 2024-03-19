using System.ComponentModel.DataAnnotations;

namespace SpinningWebApp.Models
{
    public class SpecificationViewModel
    {
        [Required]
        public string SpecificationName { get; set; } = null!;

        [Required]
        public string SpecificationValue { get; set; } = null!;
    }
}
