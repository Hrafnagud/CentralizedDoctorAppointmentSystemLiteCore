using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.Models
{
    [Table("Appointments")]
    public class Appointment : Base<int>
    {
        [Required]
        public string PatientId { get; set; }
        [ForeignKey("PatientId")]
        public int HospitalClinicId { get; set; }
        [ForeignKey("HospitalClinicId")]

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Appointment Hour format must as follows! => XX:XX")]
        public string AppointmentHour { get; set; }
        public virtual Patient Patient{ get; set; }

        public virtual HospitalClinic HospitalClinic{ get; set; }


    }
}
