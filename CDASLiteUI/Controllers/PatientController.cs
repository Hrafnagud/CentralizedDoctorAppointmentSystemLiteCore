using CDASLiteBusinessLogicLayer.Contracts;
using CDASLiteBusinessLogicLayer.EmailService;
using CDASLiteEntityLayer.IdentityModels;
using CDASLiteEntityLayer.Models;
using CDASLiteUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDASLiteUI.Controllers
{
    public class PatientController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IEmailSender emailSender;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;

        public PatientController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IEmailSender emailSender, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.emailSender = emailSender;
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
        }

        [Authorize]
        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [Authorize]
        public IActionResult Appointment()
        {
            try
            {
                ViewBag.Cities = unitOfWork.CityRepository.GetAll(orderBy: x => x.OrderBy(a => a.CityName));
                ViewBag.Clinics = unitOfWork.ClinicRepository.GetAll(orderBy: x => x.OrderBy(a => a.ClinicName));
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [Authorize]
        public IActionResult FindAppointmentOldVersion(int cityid, int? distid, int cid, int? hid, int? dr){
            try
            {
                //Receive HospitalClinic from obtained clinicid
                var data = unitOfWork.HospitalClinicRepository.GetAll(x => x.ClinicId == cid && x.HospitalId == hid.Value).Select(a => a.AppointmentHours).ToList();
                var list = new List<PatientAppointmentViewModel>();
                foreach (var item in data)
                {
                    foreach (var subitem in item)
                    {
                        var hospitalClinicData = unitOfWork.HospitalClinicRepository.GetFirstOrDefault(x => x.Id == subitem.HospitalClinicId);
                        var hours = subitem.Hours.Split(',');
                        var appointment = unitOfWork.AppointmentRepository.GetAll(
                            x => x.HospitalClinicId == subitem.HospitalClinicId && (x.AppointmentDate > DateTime.Now.AddDays(-1) && x.AppointmentDate < DateTime.Now.AddDays(2))
                            ).ToList();
                        foreach (var houritem in hours)
                        {
                            if (appointment.Count(x => x.AppointmentDate == (Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString())) && x.AppointmentHour == houritem) == 0)
                            {
                                list.Add(new PatientAppointmentViewModel()
                                {
                                    AppointmentDate = Convert.ToDateTime(DateTime.Now.AddDays(1)),
                                    HospitalClinicId = subitem.HospitalClinicId,
                                    DoctorId = hospitalClinicData.DoctorId,
                                    AvailableHour = houritem,
                                    Doctor = unitOfWork.DoctorReposittory.GetFirstOrDefault(x => x.TRID == hospitalClinicData.DoctorId, includeProperties:"AppUser")
                                });
                            }
                        }
                    }
                }

                list = list.Distinct().OrderBy(x=> x.AppointmentDate).ToList();
                return View(list);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        public IActionResult FindAppointment(int cityid, int? distid, int cid, int? hid, int? dr)
        {
            try
            {
                TempData["ClinicId"] = cid;
                TempData["HospitalId"] = hid.Value;
                //Dışarıdan gelen hid ve clinicid'nin olduğu HospitalClinic kayıtlarını al
                var data = unitOfWork.HospitalClinicRepository
                    .GetAll(x => x.ClinicId == cid
                    && x.HospitalId == hid.Value)
                    .Select(a => a.AppointmentHours)
                    .ToList();

                var list = new List<AvailableDoctorAppointmentViewModel>();

                foreach (var item in data)
                {
                    foreach (var subitem in item)
                    {
                        var hospitalClinicData =
                            unitOfWork.HospitalClinicRepository
                            .GetFirstOrDefault(x => x.Id == subitem.HospitalClinicId);

                        var hours = subitem.Hours.Split(',');
                        var appointment = unitOfWork
                            .AppointmentRepository
                            .GetAll(
                            x => x.HospitalClinicId == subitem.HospitalClinicId
                            &&
                            (x.AppointmentDate > DateTime.Now.AddDays(-1)
                            &&
                            x.AppointmentDate < DateTime.Now.AddDays(2)
                            )
                            ).ToList();
                        foreach (var houritem in hours)
                        {
                            if (appointment.Count(
                                x =>
                                x.AppointmentDate == (
                                Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString())) &&
                                x.AppointmentHour == houritem
                                ) == 0)
                            {

                                list.Add(new AvailableDoctorAppointmentViewModel()
                                {
                                    HospitalClinicId = subitem.HospitalClinicId,
                                    ClinicId = hospitalClinicData.ClinicId,
                                    HospitalId = hospitalClinicData.HospitalId,
                                    DoctorTRID = hospitalClinicData.DoctorId,
                                    Doctor = unitOfWork.DoctorReposittory
                                    .GetFirstOrDefault(x => x.TRID ==
                                    hospitalClinicData.DoctorId, includeProperties: "AppUser"),
                                    Hospital = unitOfWork.HospitalRepository
                                    .GetFirstOrDefault(x => x.Id ==
                                    hospitalClinicData.HospitalId),
                                    Clinic = unitOfWork.ClinicRepository
                                    .GetFirstOrDefault(x => x.Id == hospitalClinicData.ClinicId),
                                    HospitalClinic = hospitalClinicData
                                });
                                break;
                            }

                        }

                    }
                }

                list = list.Distinct().OrderBy(x => x.Doctor.AppUser.Name).ToList();
                return View(list);


            }
            catch (Exception)
            {

                throw;
            }

        }

        [Authorize]
        public IActionResult FindAppointmentHours(int hcid)
        {
            try
            {

                var list = new List<AvailableDoctorAppointmentHoursViewModel>();

                var data = unitOfWork.
                    AppointmentHourRepository.
                    GetFirstOrDefault(x => x.HospitalClinicId == hcid);

                var hospitalClinicData =
                         unitOfWork.HospitalClinicRepository
                         .GetFirstOrDefault(x => x.Id == hcid);
                Doctor dr = unitOfWork.DoctorReposittory
                    .GetFirstOrDefault(x => x.TRID == hospitalClinicData.DoctorId
                    , includeProperties: "AppUser");
                ViewBag.Doctor = "Dr." + dr.AppUser.Name + " " + dr.AppUser.Surname;


                var hours = data.Hours.Split(',');

                var appointment = unitOfWork
                    .AppointmentRepository
                    .GetAll(
                    x => x.HospitalClinicId == hcid
                    &&
                    (x.AppointmentDate > DateTime.Now.AddDays(-1)
                    &&
                    x.AppointmentDate < DateTime.Now.AddDays(2)
                    )
                    ).ToList();

                foreach (var houritem in hours)
                {
                    string myHourBase = houritem.Substring(0, 2) + ":00";
                    var appointmentHourData =
                      new AvailableDoctorAppointmentHoursViewModel()
                      {
                          AppointmentDate = DateTime.Now.AddDays(1),
                          Doctor = dr,
                          HourBase = myHourBase,
                          HospitalClinicId = hcid
                      };
                    if (list.Count(x => x.HourBase == myHourBase) == 0)
                    {
                        list.Add(appointmentHourData);
                    }
                    if (appointment.Count(
                        x =>
                        x.AppointmentDate == (
                        Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString())) &&
                        x.AppointmentHour == houritem
                        ) == 0)
                    {
                        if (list.Count(x => x.HourBase == myHourBase) > 0)
                        {
                            list.Find(x => x.HourBase == myHourBase
                                ).Hours.Add(houritem);
                        }
                    }
                }
                return View(list);
            }
            catch (Exception)
            {

                throw;
            }
        }



        [Authorize]
        public JsonResult SaveAppointment(int hcid, string date, string hour)
        {
            var message = String.Empty;
            try
            {
                //Check whether an appointment exists for the exact same time interval
                DateTime appointmentDate = Convert.ToDateTime(date);
                if (unitOfWork.AppointmentRepository.GetFirstOrDefault(x => x.AppointmentDate == appointmentDate && x.AppointmentHour == hour) != null)
                {
                    message = $"You have already booked an appointment for the following date {date} - {hour}.";
                    return Json(new { isSuccess = false, message });
                }
                //save appointment
                Appointment patientAppointment = new Appointment()
                {
                    CreatedDate = DateTime.Now,
                    PatientId = HttpContext.User.Identity.Name,
                    HospitalClinicId = hcid,
                    AppointmentDate = appointmentDate,
                    AppointmentHour = hour,
                    
                };
                var result = unitOfWork.AppointmentRepository.Add(patientAppointment);
                message = result ? "Appointment has been successfully booked." : "An unexpected error has occured";
                return result ? Json(new { isSuccess = true, message }) : Json(new { isSuccess = false, message });
            }
            catch (Exception ex)
            {
                message = $"Error: {ex.Message}";
                return Json(new { isSuccess = false, message });
            }
        }
    }
}
