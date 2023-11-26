using Donations.Common.Email.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.Common.Email.Services
{
    internal class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config) {
            _config = config;
        }
        public void SendEmail(EmailDto reques)
        {
            var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailHost").Value));
            email.From.Add(MailboxAddress.Parse("marcelle21@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(reques.To));
            email.Subject = reques.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = reques.Body };

            using var smtp = new SmtpClient();
            //smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            //smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("marcelle21@ethereal.email", "AexjVPMCFyeCFJcmHk");
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}
