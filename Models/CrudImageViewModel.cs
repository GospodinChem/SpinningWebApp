using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinningWebApp.Models
{
    public class CrudImageViewModel
    {
        [Required]
        public string ImageURL { get; set; } = null!;

        [Required]
        public Guid ProductId { get; set; }
    }
}
