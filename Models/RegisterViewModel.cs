using System.ComponentModel.DataAnnotations;

namespace SpinningWebApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [Compare("PasswordRepeat")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string PasswordRepeat { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string City { get; set; } = null!;
    }
}
