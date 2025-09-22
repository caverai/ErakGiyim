using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ErakGiyim
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(64)]
        public string Username { get; set; } = string.Empty;

        [Required] public string PasswordHash { get; set; } = string.Empty;
        [Required] public string PasswordSalt { get; set; } = string.Empty;

        [MaxLength(32)]
        public string Role { get; set; } = "User"; // Default role is "User"

        public bool IsActive { get; set; } = true; // Default to active user

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
