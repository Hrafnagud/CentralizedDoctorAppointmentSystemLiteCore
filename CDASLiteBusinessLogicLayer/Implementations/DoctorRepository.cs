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
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly MyContext myContext;
        public DoctorRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
