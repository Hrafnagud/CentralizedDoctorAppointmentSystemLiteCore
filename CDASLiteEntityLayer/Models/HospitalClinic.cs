using CDASLiteEntityLayer.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.Models
{
    [Table("HospitalClinics")]
    public class HospitalClinic : Base<int>
    {
        //Hospital
        public int HospitalId { get; set; }
        [ForeignKey("HospitalId")]

        public int ClinicId { get; set; }   //Relationship with clinic
        [ForeignKey("ClinicId")]
        public virtual Clinic Clinic { get; set; }

        public string DoctorId { get; set; }    //Relationship with doctor


        public virtual Hospital Hospital { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
        public virtual List<AppointmentHour> AppointmentHours { get; set; }
        public virtual List<Appointment> ClinicAppointments { get; set; }

    }
}
