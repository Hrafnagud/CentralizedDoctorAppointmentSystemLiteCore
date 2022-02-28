﻿using CDASLiteBusinessLogicLayer.Contracts;
using CDASLiteBusinessLogicLayer.EmailService;
using CDASLiteEntityLayer;
using CDASLiteEntityLayer.Enums;
using CDASLiteEntityLayer.IdentityModels;
using CDASLiteEntityLayer.Models;
using CDASLiteUI.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        public IActionResult Index(int pageNumberPast = 1, int pageNumberFuture = 1)
        {
            try
            {
                ViewBag.PageNumberPast = pageNumberPast;
                ViewBag.PageNumberFuture= pageNumberFuture;
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
                    AppointmentStatus = AppointmentStatus.Active
                };
                var result = unitOfWork.AppointmentRepository.Add(patientAppointment);
                message = result ? "Appointment has been successfully booked." : "An unexpected error has occured";

                if (result)
                {
                    var data = unitOfWork.AppointmentRepository.GetAppointmentByID(HttpContext.User.Identity.Name,
                        patientAppointment.HospitalClinicId,
                        patientAppointment.AppointmentDate,
                        patientAppointment.AppointmentHour);

                    var user = userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;
                    var emailMessage = new EmailMessage()
                    {
                        Contacts = new string[] { },
                        Subject = "CDASLITE - Appointment Details",
                        Body =  $"Hello {user.Name} {user.Surname}, </br>PDF document related with your appointment is attached."
                    };

                    emailSender.SendAppointmentPDF(emailMessage, data);
                }

                return result ? Json(new { isSuccess = true, message }) : Json(new { isSuccess = false, message });
            }
            catch (Exception ex)
            {
                message = $"Error: {ex.Message}";
                return Json(new { isSuccess = false, message });
            }
        }

        [Authorize]
        public JsonResult CancelAppointment(int id)
        {
            var message = string.Empty;
            try
            {
                var appointment = unitOfWork.AppointmentRepository.GetFirstOrDefault(x => x.Id == id);

                if (appointment != null)
                {
                    appointment.AppointmentStatus = AppointmentStatus.Passive;
                    var result = unitOfWork.AppointmentRepository.Update(appointment);
                    message = result ? "Appointment has been cancelled" : "An unexpected error has occured";
                    return result ? Json(new { isSuccess = true, message }) : Json(new { isSuccess = false, message });
                }
                else
                {
                    message = "ERROR: Since an appointment couldn't be found, cancellation failed. Try again!";
                    return Json(new { isSuccess = false, message });
                }
            }
            catch (Exception ex)
            {
                message = "ERROR: " + ex.Message;
                return Json(new { isSuccess = false, message });
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpcomingAppointmentsExcelExport()
        {
            try
            {
                DataTable dataTable = new DataTable();
                var patientId = HttpContext.User.Identity.Name;
                var data = unitOfWork.AppointmentRepository.GetUpcomingAppointments(patientId);
                dataTable.Columns.Add("CITY");
                dataTable.Columns.Add("DISTRICT");
                dataTable.Columns.Add("HOSPITAL");
                dataTable.Columns.Add("CLINIC");
                dataTable.Columns.Add("DOCTOR");
                dataTable.Columns.Add("APPOINTMENT DATE");
                dataTable.Columns.Add("APPOINTMENT HOUR");

                foreach (var item in data)
                {
                    var doctor = item.HospitalClinic.Doctor.AppUser.Name + " " + item.HospitalClinic.Doctor.AppUser.Surname;
                    dataTable.Rows.Add( item.HospitalClinic.Hospital.HospitalDistrict.City.CityName,
                                        item.HospitalClinic.Hospital.HospitalDistrict.DistrictName,
                                        item.HospitalClinic.Hospital.HospitalName,
                                        item.HospitalClinic.Clinic.ClinicName,
                                        doctor,
                                        item.AppointmentDate,
                                        item.AppointmentHour
                        );
                }
                //Create Excel
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dataTable);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
