using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cheapware.WebApp.Models
{
    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^((?=.*[a-z]).(?=.*\d)).+$", ErrorMessage = "Password must contain Uppercase, Lowercase, and Number")]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
