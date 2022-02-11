using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.Models
{
    [Table("Hospitals")]
    public class Hospital : Base<int>
    {
        [Required]
        [StringLength(400, MinimumLength = 2, ErrorMessage = "Hospital name must consist characters between 2-400!")]
        public string HospitalName { get; set; }

        public int DistrictId { get; set; } //Every Hospital will have a District, we should add Hospital List in District class!
        [ForeignKey("DistrictId")]

        public virtual District HospitalDistrict { get; set; }

        public virtual List<HospitalClinics> HospitalClinics { get; set; }  //Hospital - HospitalClinics relationship
    }
}
