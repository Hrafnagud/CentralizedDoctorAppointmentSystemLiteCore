using AutoMapper;
using CDASLiteEntityLayer.Models;
using CDASLiteEntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteEntityLayer.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            //CreateMap<Appointment, AppointmentVM>();
            //CreateMap<AppointmentVM, Appointment>();
            //To simplify above statements, we can use reversemap method so that they can be interchangeably used
            CreateMap<AppointmentVM, Appointment>().ReverseMap();
        }
    }
}
