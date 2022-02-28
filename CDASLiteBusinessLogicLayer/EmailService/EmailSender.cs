using CDASLiteEntityLayer;
using CDASLiteEntityLayer.ViewModels;
using Microsoft.Extensions.Configuration;
using SelectPdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        public string CC => configuration.GetSection("ManagerEMails:EmailToCC").Value;

        public void SendAppointmentPDF(EmailMessage message, AppointmentVM data)
        {
            try
            {
                string htmlString =
                    "<html><head></head><body><h3>Hasta Adı:"
                    + data.Patient.AppUser.Name + " " + data.Patient.AppUser.Surname
                    + "</h3><br/>"
                    + "<h4>Aşağıda randevu bilgileriniz bulunmaktadır.</h4><br/>"
                    + "<h4>İl - İlçe: "
                    + data.HospitalClinic.Hospital.HospitalDistrict.City.CityName
                    + " - "
                    + data.HospitalClinic.Hospital.HospitalDistrict.DistrictName
                    + "</h4><br/><h4>Hastane: " + data.HospitalClinic.Hospital.HospitalName
                    + "</h4><br/>"
                    + "<h4>Klinik: " + data.HospitalClinic.Clinic.ClinicName
                    + "</h4><br/><h4>Doktor :" + data.HospitalClinic.Doctor.AppUser.Name
                    + " "
                    + data.HospitalClinic.Doctor.AppUser.Surname
                    + "</h4><br/>"
                    + "<h4>Randevu Tarihi ve Saati:"
                    + data.AppointmentDate + " - " + data.AppointmentHour
                    + "</h4></body></html>";

                // instantiate a html to pdf converter object
                HtmlToPdf converter = new HtmlToPdf();
                // create a new pdf document converting an url
                PdfDocument doc = converter.ConvertHtmlString(htmlString);

                // create memory stream to save PDF
                MemoryStream pdfStream = new MemoryStream();

                // save pdf document into a MemoryStream
                doc.Save(pdfStream);

                // reset stream position
                pdfStream.Position = 0;
                var mail = new MailMessage()
                {
                    From = new MailAddress(this.Sender)
                };

                //contacts 
                foreach (var item in message.Contacts)
                {
                    mail.To.Add(item);
                }
                //cc
                if (message.Cc != null)
                {
                    foreach (var item in message.Cc)
                    {
                        mail.CC.Add(new MailAddress(item));
                    }
                }

                if (CC != null)
                {
                    var ccData = CC.Split(',');
                    foreach (var item in ccData)
                    {
                        mail.CC.Add(new MailAddress(item));
                    }
                }
                //bcc
                if (message.Bcc != null)
                {
                    foreach (var item in message.Bcc)
                    {
                        mail.Bcc.Add(new MailAddress(item));
                    }
                }
                mail.Attachments.Add(new Attachment(pdfStream, "Document.pdf"));

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
                smtpClient.Send(mail);

                // close pdf document
                doc.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SendAppointmentPDFAsync(EmailMessage message, AppointmentVM data)
        {
            try
            {
                string htmlString =
                    "<html><head></head><body><h3>Hasta Adı:"
                    + data.Patient.AppUser.Name + " " + data.Patient.AppUser.Surname
                    + "</h3><br/>"
                    + "<h4>Aşağıda randevu bilgileriniz bulunmaktadır.</h4><br/>"
                    + "<h4>İl - İlçe: "
                    + data.HospitalClinic.Hospital.HospitalDistrict.City.CityName
                    + " - "
                    + data.HospitalClinic.Hospital.HospitalDistrict.DistrictName
                    + "</h4><br/><h4>Hastane: " + data.HospitalClinic.Hospital.HospitalName
                    + "</h4><br/>"
                    + "<h4>Klinik: " + data.HospitalClinic.Clinic.ClinicName
                    + "</h4><br/><h4>Doktor :" + data.HospitalClinic.Doctor.AppUser.Name
                    + " "
                    + data.HospitalClinic.Doctor.AppUser.Surname
                    + "</h4><br/>"
                    + "<h4>Randevu Tarihi ve Saati:"
                    + data.AppointmentDate + " - " + data.AppointmentHour
                    + "</h4></body></html>";

                // instantiate a html to pdf converter object
                HtmlToPdf converter = new HtmlToPdf();
                // create a new pdf document converting an url
                PdfDocument doc = converter.ConvertHtmlString(htmlString);

                // create memory stream to save PDF
                MemoryStream pdfStream = new MemoryStream();

                // save pdf document into a MemoryStream
                doc.Save(pdfStream);

                // reset stream position
                pdfStream.Position = 0;
                var mail = new MailMessage()
                {
                    From = new MailAddress(this.Sender)
                };

                //contacts 
                foreach (var item in message.Contacts)
                {
                    mail.To.Add(item);
                }
                //cc
                if (message.Cc != null)
                {
                    foreach (var item in message.Cc)
                    {
                        mail.CC.Add(new MailAddress(item));
                    }
                }

                if (CC != null)
                {
                    var ccData = CC.Split(',');
                    foreach (var item in ccData)
                    {
                        mail.CC.Add(new MailAddress(item));
                    }
                }
                //bcc
                if (message.Bcc != null)
                {
                    foreach (var item in message.Bcc)
                    {
                        mail.Bcc.Add(new MailAddress(item));
                    }
                }
                mail.Attachments.Add(new Attachment(pdfStream, "Document.pdf"));

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

                // close pdf document
                doc.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

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

            if (CC != null)
            {
                var ccData = CC.Split(',');
                foreach (var item in ccData)
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
