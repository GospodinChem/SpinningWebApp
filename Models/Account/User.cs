using Microsoft.AspNetCore.Identity;
using SpinningWebApp.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace SpinningWebApp.Models.Account
{
    public class User : IdentityUser
    {
        [StringLength(30)]
        public string FirstName { get; set; } = null!;

        [StringLength(30)]
        public string LastName { get; set; } = null!;

        [StringLength(30)]
        public string City { get; set; } = null!;

        public UserSession Session { get; set; } = null!;
    }
}
