using CDASLiteEntityLayer.Models;
using CDASLiteEntityLayer.PagingListModels;
using CDASLiteEntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDASLiteUI.Models
{
    public class PastAndFutureAppointmentsViewModel
    {
        //public List<Appointment> PastAppointments { get; set; }
        //public List<Appointment> UpcomingAppointments{ get; set; }

        public PaginatedList<AppointmentVM> PastAppointments { get; set; }
        public PaginatedList<AppointmentVM> UpcomingAppointments{ get; set; }
    }
}
