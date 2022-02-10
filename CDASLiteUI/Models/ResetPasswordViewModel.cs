using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDASLiteUI.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "New password is required!")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must contain at least 6 characters.")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Password repetition field is required!")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password Repeat")]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords don't match!")]
        public string ConfirmNewPassword { get; set; }
        public string Code { get; set; }
        public string UserId { get; set; }
    }
}
