using System.ComponentModel.DataAnnotations.Schema;

namespace SpinningWebApp.Data.Models
{
    public class SessionProduct
    {
        [ForeignKey("UserSession")]
        public Guid SessionId { get; set; }
        public UserSession UserSession { get; set; } = null!;

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
