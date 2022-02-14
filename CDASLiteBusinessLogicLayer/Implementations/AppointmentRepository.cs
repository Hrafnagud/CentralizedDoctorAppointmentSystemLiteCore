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
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly MyContext myContext;
        public AppointmentRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
