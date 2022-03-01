using CDASLiteBusinessLogicLayer.Contracts;
using CDASLiteEntityLayer.PagingListModels;
using CDASLiteEntityLayer.ViewModels;
using CDASLiteUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDASLiteUI.Components
{
    public class PatientAppointmentsViewComponent : ViewComponent
    {
        private readonly IUnitOfWork unitOfWork;

        //Dependency Injection
        public PatientAppointmentsViewComponent(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IViewComponentResult Invoke(int pageNumberPast = 1, int pageNumberFuture = 1)
        {
            PastAndFutureAppointmentsViewModel data = new PastAndFutureAppointmentsViewModel();
            DateTime today = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var patientId = HttpContext.User.Identity.Name;

            //Active Appointments
            var upcomingAppointments = unitOfWork.AppointmentRepository.GetUpcomingAppointments(patientId);
            data.UpcomingAppointments = PaginatedList<AppointmentVM>.CreateAsync(upcomingAppointments, pageNumberFuture, 5);

            var pastAndCancelledAppointments = unitOfWork.AppointmentRepository.GetPastAppointments(patientId);
            data.PastAppointments = PaginatedList<AppointmentVM>.CreateAsync(pastAndCancelledAppointments, pageNumberPast, 5);


            //data.UpcomingAppointments = unitOfWork.AppointmentRepository.GetAll(x => x.PatientId == HttpContext.User.Identity.Name && x.AppointmentDate > today || (x.AppointmentDate == today && (Convert.ToInt32(x.AppointmentHour.Substring(0, 2)) > DateTime.Now.Hour || (Convert.ToInt32(x.AppointmentHour.Substring(0, 2)) == DateTime.Now.Hour && Convert.ToInt32(x.AppointmentHour.Substring(3, 2)) >= DateTime.Now.Minute ))), includeProperties: "HospitalClinic").ToList();

            //data.PastAppointments = unitOfWork.AppointmentRepository.GetAll(x => x.PatientId == HttpContext.User.Identity.Name && x.AppointmentDate < today || (x.AppointmentDate == today && (Convert.ToInt32(x.AppointmentHour.Substring(0, 2)) < DateTime.Now.Hour || (Convert.ToInt32(x.AppointmentHour.Substring(0, 2)) == DateTime.Now.Hour && Convert.ToInt32(x.AppointmentHour.Substring(3, 2)) <= DateTime.Now.Minute ))), includeProperties: "HospitalClinic").ToList();
            return View(data);
        }
    }
}
