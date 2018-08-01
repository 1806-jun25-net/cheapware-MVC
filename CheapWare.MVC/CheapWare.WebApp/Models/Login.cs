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
        [RegularExpression(@"^((?=.*[A-Z]).(?=.*[a-z]).(?=.*\d)).+$", ErrorMessage = "Password must contain Uppercase, Lowercase, and Number")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
