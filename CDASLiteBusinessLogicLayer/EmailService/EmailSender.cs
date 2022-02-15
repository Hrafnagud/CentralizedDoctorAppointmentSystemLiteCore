using CDASLiteEntityLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteBusinessLogicLayer.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration configuration;
        public EmailSender(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Sender => configuration.GetSection("EmailOptions:Sender").Value;
        public string Password => configuration.GetSection("EmailOptions:Password").Value;
        public string Smtp => configuration.GetSection("EmailOptions:Smtp").Value;
        public int SmtpPort=> Convert.ToInt32(configuration.GetSection("EmailOptions:SmtpPort").Value);
        public async Task SendAsync(EmailMessage message)
        {
            var mail = new MailMessage() {
            From = new MailAddress(this.Sender),
            };

            //contacts
            foreach (var item in message.Contacts)
            {
                mail.To.Add(item);
            }

            //CC
            if (message.Cc != null)
            {
                foreach (var item in message.Cc)
                {
                    mail.CC.Add(new MailAddress(item));
                }
            }

            if (message.Bcc != null)
            {
                foreach (var item in message.Bcc)
                {
                    mail.Bcc.Add(new MailAddress(item));
                }
            }

            mail.Subject = message.Subject;
            mail.Body = message.Body;
            mail.IsBodyHtml = true;
            mail.BodyEncoding = Encoding.UTF8;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.HeadersEncoding = Encoding.UTF8;

            var smtpClient = new SmtpClient(Smtp, SmtpPort)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(Sender, Password)
            };
            await smtpClient.SendMailAsync(mail);
        }
    }
}
