using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingMailKit.Configuration.Contracts;
using UsingMailKit.Domain;
using UsingMailKit.Services.Contracts;

namespace UsingMailKit.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(IEmailConfiguration configuration)
        {
            _emailConfiguration = configuration;
        }                

        public void Send(EmailMessage message)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.To.AddRange(message.ToAddresses.Select(a => new MailboxAddress(a.Name, a.Address)));
            mimeMessage.From.AddRange(message.FromAddresses.Select(a => new MailboxAddress(a.Name, a.Address)));
            mimeMessage.Subject = message.Subject;            
            mimeMessage.Body = new TextPart(TextFormat.Plain)
            {
                Text = message.Content
            };
            
            using (var emailClient = new SmtpClient())
            {                
                emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, false); //no ssl for now
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                emailClient.Send(mimeMessage);
                emailClient.Disconnect(true);
            }

        }
    }
}
