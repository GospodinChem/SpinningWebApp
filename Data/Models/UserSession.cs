using SpinningWebApp.Data.Models;
using SpinningWebApp.Models.Account;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinningWebApp.Data.Models
{
    public class UserSession
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public SessionType SessionType { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;

        public ICollection<SessionProduct> SessionProducts { get; set; } = null!;
    }
}
