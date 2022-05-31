using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IEmailServices
    {
        Task SendEmailAsync(string emailTo, string subject, string htmlContent, string plainTextContent = "");
    }
}
