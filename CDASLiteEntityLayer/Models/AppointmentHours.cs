using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.Models
{
    public class AppointmentHours : Base<int>
    {
        public int HospitalClinicId { get; set; }
        [ForeignKey("HospitalClinicId")]

        [Required]
        public string Hours { get; set; }

        public virtual HospitalClinics GetHospitalClinics { get; set; }
    }
}
