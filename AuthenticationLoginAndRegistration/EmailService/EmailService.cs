using AuthenticationLoginAndRegistration.Data.Entities;
using AuthenticationLoginAndRegistration.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;


namespace AuthenticationLoginAndRegistration.EmailService
{
   
    public class EmailService : IEmailService
    {

        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> option)
        {
            _emailSettings = option.Value;
        }

        public async Task Send(string email, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_emailSettings.Username));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            using var sender = new SmtpClient();
            sender.Connect(_emailSettings.Server, _emailSettings.Port, SecureSocketOptions.StartTls);
            sender.Authenticate(_emailSettings.Username, _emailSettings.Password);
            //sender.Disconnect(true);
            await sender.SendAsync(message);
        }
    }
}
