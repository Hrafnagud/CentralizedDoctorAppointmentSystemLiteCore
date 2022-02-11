using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.Models
{
    [Table("AppointmentHours")]
    public class AppointmentHour : Base<int>
    {
        public int HospitalClinicId { get; set; }
        [ForeignKey("HospitalClinicId")]

        [Required]
        public string Hours { get; set; }

        public virtual HospitalClinic GetHospitalClinic{ get; set; }
    }
}
