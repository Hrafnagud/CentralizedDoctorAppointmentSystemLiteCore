using CDASLiteEntityLayer.Models;
using CDASLiteEntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteBusinessLogicLayer.Contracts
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        List<AppointmentVM> GetUpcomingAppointments(string patientId);
        List<AppointmentVM> GetPastAppointments(string patientId);
        AppointmentVM GetAppointmentByID(string patientId, int hcid, DateTime appointmentDate, string appointmentHour);
        List<AppointmentVM> GetAppointmentsIM(DateTime? dt);
        

    }
}
