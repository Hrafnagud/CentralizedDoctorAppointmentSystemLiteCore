using CDASLiteEntityLayer.Enums;
using CDASLiteEntityLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.IdentityModels
{
    public class AppUser : IdentityUser
    {
        [StringLength(50,MinimumLength = 2, ErrorMessage = "Name must contain characters between 2-50")]
        [Required(ErrorMessage = "Name field is required!")]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Surname must contain characters between 2-50")]
        [Required(ErrorMessage = "Surname field is required!")]
        public string Surname { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegisterDate { get; set; } = DateTime.Now;

        public string Picture { get; set; }
        [DataType(DataType.Date)]

        public DateTime? BirtDate { get; set; }
        [Required(ErrorMessage = "Gender field is required")]
        public Genders Gender { get; set; }

        public virtual List<Doctor> Doctors{ get; set; }    //Doctor table relation established
        public virtual List<Patient> Patients{ get; set; }  //Patient table relation established
    }
}
