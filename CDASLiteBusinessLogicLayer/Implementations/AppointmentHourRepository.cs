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
    public class AppointmentHourRepository : Repository<AppointmentHour>, IAppointmentHourRepository
    {
        private readonly MyContext myContext;
        public AppointmentHourRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
