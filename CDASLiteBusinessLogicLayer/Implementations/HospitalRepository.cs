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
    public class HospitalRepository : Repository<Hospital>, IHospitalRepository
    {
        private readonly MyContext myContext;
        public HospitalRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
