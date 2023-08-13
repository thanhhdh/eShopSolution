using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static eShopSolution.Utilities.Constants.SystemConstants;

namespace EmailService
{
    public class EmailService : IEmailService
    {
        public void Send(string from, string to, string subject, string text)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;

            // Send text format
            //email.Body = new TextPart(TextFormat.Plain) { Text = text };

            // Send html format
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = string.Format(text)
            };

            // send email
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("hdhthanh.20it3@vku.udn.vn", "");

            try
            {
                smtp.Send(email);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}