using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace HepsiSef.Model
{
    public static class MailManager
    {
        public static void Send(string body, string mail)
        {

            var fromAdress = new MailAddress("cihanoguz92@gmail.com");
            var toAdress = new MailAddress(mail);
            const string subject = "Hepsişef | sadfsd";

            using (var smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAdress.Address, "Yorumyok2**")
            })
            {
                using (var message = new MailMessage(fromAdress, toAdress) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }





        }
    }
}
