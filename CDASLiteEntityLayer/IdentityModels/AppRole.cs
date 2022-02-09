using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.IdentityModels
{
    public class AppRole : IdentityRole
    {
        [StringLength(400, ErrorMessage = "Role Description can have utmost 400 characters!")]
        public string Description{ get; set; }
    }
}
