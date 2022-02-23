using CDASLiteEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDASLiteUI.Models
{
    public class AvailableDoctorAppointmentViewModel
    {
        public string DoctorTRID { get; set; }
        public Doctor Doctor { get; set; }
        public int HospitalClinicId { get; set; }
        public HospitalClinic HospitalClinic { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital{ get; set; }
    }
}
