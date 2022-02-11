using CDASLiteEntityLayer.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.Models
{
    [Table("Doctors")]
    public class Doctor : PersonBase
    {
        public string UserId { get; set; }      // Identity model's id will be the foreign key here.
        [ForeignKey("UserId")]
        public virtual AppUser AppUser{ get; set; }
        public virtual List<HospitalClinic> HospitalClinics { get; set; }
    }
}
