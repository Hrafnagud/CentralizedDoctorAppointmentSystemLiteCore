using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.Models
{
    [Table("Clinics")]
    public class Clinic : Base<int>
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Clinic name must contain characters between 2-50!")]
        public string ClinicName { get; set; }

        public virtual List<HospitalClinic> HospitalClinics { get; set; }  //HospitalClinics - Clinic relationship
    }
}
