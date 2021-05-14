using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace lesson1
{
    public class MailEngine
    {
        /*MailAddress FromAddress;
        MailAddress toAddress;
        SmtpClient SMTP;*/
        public MailEngine(string address, string your_name, string to, string smtp,
        string port, string password, string body, string sign)
        {
            var FromAddress = new MailAddress(address, your_name);
            var toAddress = new MailAddress(to);
            var SMTP = new SmtpClient
            {
                Host = smtp,
                Port = int.Parse(port),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(address, password)
            };
            using (var message = new MailMessage(FromAddress, toAddress)
            {
                Subject = "",
                Body = body + "/n" + sign,
            })
            {
                SMTP.Send(message);
            }
        }

        
    }
}
