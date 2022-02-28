using CDASLiteEntityLayer;
using CDASLiteEntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteBusinessLogicLayer.EmailService
{
    public interface IEmailSender
    {
        Task SendAsync(EmailMessage message);

        void SendAppointmentPDF(EmailMessage message, AppointmentVM data);
        Task SendAppointmentPDFAsync(EmailMessage message, AppointmentVM data);
    }
}
