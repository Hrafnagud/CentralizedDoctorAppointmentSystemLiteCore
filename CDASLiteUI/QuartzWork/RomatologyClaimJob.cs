using CDASLiteBusinessLogicLayer.Contracts;
using CDASLiteEntityLayer.Enums;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDASLiteUI.QuartzWork
{
    [DisallowConcurrentExecution]
    public class RomatologyClaimJob : IJob
    {
        private readonly ILogger<RomatologyClaimJob> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public RomatologyClaimJob(ILogger<RomatologyClaimJob> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                var date = DateTime.Now.AddMonths(-1);
                //son bir aydaki iptal olanlar hariç tüm randevuları getir
                var appointment = _unitOfWork.AppointmentRepository.GetAppointmentsIM(date).OrderByDescending(x => x.AppointmentDate).ToList();
                foreach (var item in appointment)
                {
                    //If IM => Romatology claim doesn't exist, we'll add it in here.
                    
                }
            }
            catch (Exception ex)
            {
                //will be logged
            }
            //}
        }
    }
}
