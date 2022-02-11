using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.Models
{
    [Table("DoctorId")]
    public class Doctor : Base<string>
    {
        public virtual List<HospitalClinics> HospitalClinics { get; set; }
    }
}
