using AutoMapper;
using CDASLiteBusinessLogicLayer.Contracts;
using CDASLiteDataAccessLayer;
using CDASLiteEntityLayer.Enums;
using CDASLiteEntityLayer.IdentityModels;
using CDASLiteEntityLayer.Models;
using CDASLiteEntityLayer.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDASLiteEntityLayer.Constants;

namespace CDASLiteBusinessLogicLayer.Implementations
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        public AppointmentRepository(MyContext myContext, IMapper mapper, UserManager<AppUser> userManager) : base(myContext)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public AppointmentVM GetAppointmentByID(string patientId, int hcid, DateTime appointmentDate, string appointmentHour)
        {
            try
            {
                var data = GetFirstOrDefault(x => x.PatientId == patientId && x.HospitalClinicId == hcid && x.AppointmentDate == appointmentDate && x.AppointmentHour== appointmentHour, includeProperties: "HospitalClinic,Patient");
                if (data != null)
                {
                    //Hospital
                    data.HospitalClinic.Hospital = myContext.Hospitals.FirstOrDefault(x => x.Id == data.HospitalClinic.HospitalId);
                    //Clinic
                    data.HospitalClinic.Clinic = myContext.Clinics.FirstOrDefault(x => x.Id == data.HospitalClinic.ClinicId);
                    //District
                    data.HospitalClinic.Hospital.HospitalDistrict = myContext.Districts.FirstOrDefault(x => x.Id == data.HospitalClinic.Hospital.DistrictId);
                    //City
                    data.HospitalClinic.Hospital.HospitalDistrict.City = myContext.Cities.FirstOrDefault(x => x.Id == data.HospitalClinic.Hospital.HospitalDistrict.CityId);
                    //Doctor
                    data.HospitalClinic.Doctor = myContext.Doctors.FirstOrDefault(x => x.TRID == data.HospitalClinic.DoctorId);
                    //Appuser => TRID is recorded as username
                    data.HospitalClinic.Doctor.AppUser = userManager.FindByNameAsync(data.HospitalClinic.DoctorId).Result;

                    var returnData = mapper.Map<Appointment, AppointmentVM>(data);
                    return returnData;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AppointmentVM> GetPastAppointments(string patientId)
        {
            try
            {
                var data = GetAll(x => x.PatientId == patientId && x.AppointmentStatus != AppointmentStatus.Active, includeProperties: "HospitalClinic,Patient").ToList();
                foreach (var item in data)
                {
                    //Hospital
                    item.HospitalClinic.Hospital = myContext.Hospitals.FirstOrDefault(x => x.Id== item.HospitalClinic.HospitalId);                                              
                    //Clinic
                    item.HospitalClinic.Clinic = myContext.Clinics.FirstOrDefault(x => x.Id == item.HospitalClinic.ClinicId);                                                   
                    //District
                    item.HospitalClinic.Hospital.HospitalDistrict = myContext.Districts.FirstOrDefault(x => x.Id == item.HospitalClinic.Hospital.DistrictId);                  
                    //City
                    item.HospitalClinic.Hospital.HospitalDistrict.City = myContext.Cities.FirstOrDefault(x => x.Id == item.HospitalClinic.Hospital.HospitalDistrict.CityId);
                    //Doctor
                    item.HospitalClinic.Doctor = myContext.Doctors.FirstOrDefault(x => x.TRID == item.HospitalClinic.DoctorId);
                    //Appuser => TRID is recorded as username
                    item.HospitalClinic.Doctor.AppUser = userManager.FindByNameAsync(item.HospitalClinic.DoctorId).Result;
                }
                var returnData = mapper.Map<List<Appointment>, List<AppointmentVM>>(data);
                return returnData;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AppointmentVM> GetUpcomingAppointments(string patientId)
        {
            try
            {
                var data = GetAll(x => x.PatientId == patientId && x.AppointmentStatus == AppointmentStatus.Active, includeProperties: "HospitalClinic,Patient").ToList();
                foreach (var item in data)
                {
                    //Hospital
                    item.HospitalClinic.Hospital = myContext.Hospitals.FirstOrDefault(x => x.Id == item.HospitalClinic.HospitalId);
                    //Clinic
                    item.HospitalClinic.Clinic = myContext.Clinics.FirstOrDefault(x => x.Id == item.HospitalClinic.ClinicId);
                    //District
                    item.HospitalClinic.Hospital.HospitalDistrict = myContext.Districts.FirstOrDefault(x => x.Id == item.HospitalClinic.Hospital.DistrictId);
                    //City
                    item.HospitalClinic.Hospital.HospitalDistrict.City = myContext.Cities.FirstOrDefault(x => x.Id == item.HospitalClinic.Hospital.HospitalDistrict.CityId);
                    //Doctor
                    item.HospitalClinic.Doctor = myContext.Doctors.FirstOrDefault(x => x.TRID == item.HospitalClinic.DoctorId);
                    //Appuser => TRID is recorded as username
                    item.HospitalClinic.Doctor.AppUser = userManager.FindByNameAsync(item.HospitalClinic.DoctorId).Result;
                }
                var returnData = mapper.Map<List<Appointment>, List<AppointmentVM>>(data);
                return returnData;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Brings appointments which is behind of the given date
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<AppointmentVM> GetAppointmentsIM(DateTime? dt)
        {
            try
            {
                List<AppointmentVM> data = new List<AppointmentVM>();
                var result = from a in myContext.Appointments
                             join hcid in myContext.HospitalClinics
                             on a.HospitalClinicId equals hcid.Id
                             join c in myContext.Clinics
                             on hcid.ClinicId equals c.Id
                             where c.ClinicName == ClinicsConstants.INTERNAL_MEDICINE && a.AppointmentStatus == AppointmentStatus.Passive
                             select a;
                if (dt != null)
                {
                    var date = Convert.ToDateTime(dt.Value.ToString("dd/MM/yyyy"));
                    result = result.Where(x => x.AppointmentDate >= date);
                }

                foreach (var item in result)
                {
                    item.Patient = myContext.Patients.FirstOrDefault(x => x.TRID == item.PatientId);
                    
                    item.Patient.AppUser = userManager.FindByNameAsync(item.PatientId).Result;

                }

                data = mapper.Map<List<Appointment>, List<AppointmentVM>>(result.ToList());
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
