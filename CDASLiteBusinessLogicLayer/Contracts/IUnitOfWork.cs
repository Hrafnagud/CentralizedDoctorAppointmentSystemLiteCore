using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteBusinessLogicLayer.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICityRepository CityRepository { get; }
        IDistrictRepository DistrictRepository { get; }
        IDoctorRepository DoctorReposittory { get; }
        IPatientRepository PatientReposittory { get; }
        IHospitalRepository HospitalRepository { get; }
        IClinicRepository ClinicRepository { get; }
        IHospitalClinicRepository HospitalClinicRepository { get; }
        IAppointmentHourRepository AppointmentHourRepository { get; }
        IAppointmentRepository AppointmentRepository { get; }

    }
}
