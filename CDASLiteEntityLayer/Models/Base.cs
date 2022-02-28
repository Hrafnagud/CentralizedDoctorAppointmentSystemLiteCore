using CDASLiteEntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.Models
{
    public class Base<T> : IBase
    {
        public T Id { get; set; }
        public DateTime CreatedDate{ get; set; }
        [Required]
        public string PatientId { get; set; }
        public int HospitalClinicId { get; set; }
        [Required]  
        public DateTime AppointmentDate { get; set; }
        [Required]
        public string AppointmentHour { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public Patient Patient { get; set; }
        public HospitalClinic HospitalClinic { get; set; }

    }
}
