using CDASLiteEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDASLiteUI.Models
{
    public class AvailableDoctorAppointmentHoursViewModel
    {
        public Doctor Doctor { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string HourBase { get; set; }
        public List<string> Hours { get; set; } = new List<string>();
        //public Dictionary<string, bool> HourList{ get; set; }
    }
}
