using CDASLiteEntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDASLiteUI.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Turkis Republican ID")]
        [MinLength(11)]
        [StringLength(11, ErrorMessage = "TRID must consist 11 digits!")]
        public string TRID { get; set; }

        [Display(Name = "Username")]
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

        [Required(ErrorMessage = "Gender details must be provided!")]
        public Genders Gender { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Date of Birth")]
        public DateTime BirtDate { get; set; }
    }
}
