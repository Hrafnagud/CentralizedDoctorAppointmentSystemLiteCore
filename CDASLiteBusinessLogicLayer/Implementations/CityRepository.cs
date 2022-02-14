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
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
