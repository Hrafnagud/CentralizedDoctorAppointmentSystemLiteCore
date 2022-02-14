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
    public class ClinicRepository : Repository<Clinic>, IClinicRepository
    {
        private readonly MyContext myContext;
        public ClinicRepository(MyContext myContext) : base(myContext)
        {
            //Normally, ctor handles this from where we inherit. If we'll have a case which we can't surmount with generic structure, this.myContext will allow us to implement a method.
            this.myContext = myContext;
        }

    }
}
