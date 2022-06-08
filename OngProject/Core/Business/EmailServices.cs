using Microsoft.Extensions.Configuration;
using OngProject.Core.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class EmailServices : IEmailServices
    {
        private IConfiguration Configuration { get; }
        public string ApiKey { get; set; }
        public string ApiId { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }

        public EmailServices(IConfiguration configuration)
        {
            Configuration = configuration;
            ApiKey = Configuration.GetSection($"SendGrid:{nameof(ApiKey)}").Value;
            FromEmail = Configuration.GetSection($"SendGrid:{nameof(FromEmail)}").Value;
            FromName = Configuration.GetSection($"SendGrid:{nameof(FromName)}").Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlContent, string plainTextContent = "SendGrid")
        {
            var client = new SendGridClient(ApiKey);
            var from = new EmailAddress(FromEmail, FromName);

            var to = new EmailAddress(email, email);

            //var plainTextContent = "and easy to do anywhere, even with C#";
            //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
