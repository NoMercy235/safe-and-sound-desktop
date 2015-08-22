using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SnS.Functions;

namespace SnS.Classes
{
    class EmailSender
    {
        public static void sendEmail()
        {
            var fromAddress = new MailAddress("logger.test12345@gmail.com", "From Name");
            var toAddress = new MailAddress("logger.test12345@gmail.com", "To Name");
            const string fromPassword = "logtest123";
            const string subject = "Subject";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                string[] fileEntries = Directory.GetFiles(GlobalVariables.rootFolder);
                foreach (string fileName in fileEntries)
                    message.Attachments.Add(new Attachment(fileName));

                
                smtp.Send(message);
            }
        }

        public static void warningEmail(string path)
        {
            var fromAddress = new MailAddress("logger.test12345@gmail.com", "From Name");
            var toAddress = new MailAddress("logger.test12345@gmail.com", "To Name");
            string fromPassword = "logtest123";
            string subject = "Warning";
            string body = "Baaa!" + path;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
