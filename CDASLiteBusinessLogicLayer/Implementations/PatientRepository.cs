using CDASLiteBusinessLogicLayer.Contracts;
using CDASLiteDataAccessLayer;
using CDASLiteEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteBusinessLogicLayer.Implementations
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly MyContext myContext;
        public PatientRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
