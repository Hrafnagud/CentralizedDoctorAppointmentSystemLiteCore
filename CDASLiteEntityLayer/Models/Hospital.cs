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

        [StringLength(500, ErrorMessage = "Adress details must contain utmost 500 characters!")]
        public string Address { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must contain exactly 10 characters, without zero at the beginning!")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District HospitalDistrict { get; set; }

        public virtual List<HospitalClinic> HospitalClinics { get; set; }  //Hospital - HospitalClinics relationship
    }
}
