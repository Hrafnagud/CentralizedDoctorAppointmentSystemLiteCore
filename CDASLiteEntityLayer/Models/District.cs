using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.Models
{
    [Table("Districts")]
    public class District : Base<int>
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "District name must consist characters between 2-50!")]
        public string DistrictName{ get; set; }

        public int CityId { get; set; } //Every district will have a city
        [ForeignKey("CityId")]

        public virtual City City { get; set; }  

        public virtual List<Hospital> DistrictHospitals { get; set; }   
    }
}
