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
        }

        public ICityRepository CityRepository { get; private set; }

        public IDistrictRepository DistrictRepository { get; private set; }

        public IDoctorRepository DoctorReposittory { get; private set; }
        public IPatientRepository PatientReposittory { get; private set; }

        public void Dispose()
        {
            myContext.Dispose();
        }
    }
}
