using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace NorthWindSepet.Helpers
{
    public class MailHelper
    {
        public static void SendEmail(string email, string subject, string message)
        {
            //Sender
            MailMessage sender = new MailMessage();
            sender.From = new MailAddress("yzl3156yzl@gmail.com", "YZL3156");
            sender.To.Add(email); //Mailin gideceği kişi paratre dışarında parametre olarak veriliyor.
            sender.Subject = subject; // Mailin konusu
            sender.Body = message; // Mailin içeriği
            sender.IsBodyHtml = true;


            //Smtp
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("yzl3156yzl@gmail.com", "Yzl3156--"); // Hesap bilgileri içerir
            smtp.Port = 587; // Gmail için geçerli farklı mail servislerinde farklı port numarası olabilir.
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

            smtp.Send(sender);

            //NOT!!
            //Eğer tanımlı gmail hesabınız üzerinden mail göndermek istediğinizde bir hata ile karşılaşıyorsanız aşağıdaki link üzerinden izin tanımlaması yapmanız gerekmektedir.
            //https://www.google.com/settings/security/lesssecureapps

        }
    }
}