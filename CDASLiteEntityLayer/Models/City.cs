using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.Models
{
    [Table("Cities")]
    public class City : Base<byte>
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "City name must consist characters between 2-50!")]
        public string CityName { get; set; }

        [Required]
        public byte PlateCode { get; set; }
        
        //Will have a relation  with District
        public virtual List<District> Districts { get; set; }   //City will have more than one districts, that's why we should keep a list of districts for cities
    }
}
