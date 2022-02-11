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
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        private readonly MyContext myContext;
        public DistrictRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
