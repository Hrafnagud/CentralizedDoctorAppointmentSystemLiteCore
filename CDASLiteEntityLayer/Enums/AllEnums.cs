using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.Enums
{
    public class AllEnums
    {
    }

    public enum Genders : byte
    {
        Indetermined,
        Male,
        Female
    }

    public enum RoleNames : byte
    {
        Passive,
        Admin,
        Patient,
        PassiveDoctor,
        ActiveDoctor
    }

    public enum AppointmentStatus : byte
    {
        Passive,
        Active,
        Cancelled
    }
}
