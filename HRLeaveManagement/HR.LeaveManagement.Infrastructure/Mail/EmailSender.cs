using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HR.LeaveManagement.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        
        private EmailSettings _emailSettings { get; }

        public EmailSender(IOptions<EmailSettings> emailSettings) //that because it comes from appsettings configuration.
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Name = _emailSettings.FromName,
                Email = _emailSettings.FromAddress
            };
            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);
            return response.StatusCode is System.Net.HttpStatusCode.OK or System.Net.HttpStatusCode.Accepted;
        }
    }
}