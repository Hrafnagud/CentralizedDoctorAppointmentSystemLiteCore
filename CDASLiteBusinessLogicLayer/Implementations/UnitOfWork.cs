using CDASLiteBusinessLogicLayer.Contracts;
using CDASLiteDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteBusinessLogicLayer.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext myContext;

        public UnitOfWork(MyContext myContext)
        {
            this.myContext = myContext;
            //Unit of work will be able to create all repositories! Dependancy Injection!
            CityRepository = new CityRepository(this.myContext);
            DistrictRepository = new DistrictRepository(this.myContext);
            DoctorReposittory = new DoctorRepository(this.myContext);
            PatientReposittory= new PatientRepository(this.myContext);
            HospitalRepository = new HospitalRepository(this.myContext);
            ClinicRepository = new ClinicRepository(this.myContext);
            HospitalClinicRepository = new HospitalClinicRepository(this.myContext);
            AppointmentHourRepository = new AppointmentHourRepository(this.myContext);
            AppointmentRepository = new AppointmentRepository(this.myContext);
        }

        public ICityRepository CityRepository { get; private set; }

        public IDistrictRepository DistrictRepository { get; private set; }

        public IDoctorRepository DoctorReposittory { get; private set; }
        public IPatientRepository PatientReposittory { get; private set; }

        public IHospitalRepository HospitalRepository { get; private set; }

        public IClinicRepository ClinicRepository { get; private set; }
        public IHospitalClinicRepository HospitalClinicRepository { get; private set; }

        public IAppointmentHourRepository AppointmentHourRepository { get; private set; }

        public IAppointmentRepository AppointmentRepository { get; private set; }

        public void Dispose()
        {
            myContext.Dispose();
        }
    }
}
