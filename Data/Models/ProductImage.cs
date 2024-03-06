using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SpinningWebApp.Data.Models
{
    public class ProductImage
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ImageURL { get; set; } = null!;

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
