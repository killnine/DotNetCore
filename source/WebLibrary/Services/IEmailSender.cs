using System.Threading.Tasks;

namespace WebLibrary.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
