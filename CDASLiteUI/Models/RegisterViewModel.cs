using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDASLiteUI.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username field is required!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Name field is required!")]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname field is required!")]
        [Display(Name = "Surname")]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email field is required!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password field is required!")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must consist at least 6 characters!")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password repetition is required!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password Repeat")]
        [Compare(nameof(Password), ErrorMessage = "Passwords doesn't match!")]
        public string ConfirmPassword { get; set; }
    }
}
