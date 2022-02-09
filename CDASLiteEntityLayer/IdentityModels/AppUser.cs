using CDASLiteEntityLayer.Enums;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.IdentityModels
{
    public class AppUser : IdentityUser
    {
        public string Picture { get; set; }

        public DateTime? BirtDate { get; set; }

        public Genders Gender { get; set; }
    }
}
