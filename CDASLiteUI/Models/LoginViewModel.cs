using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDASLiteUI.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username field is required!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password field is required!")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must contain at least 6 characters!")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
