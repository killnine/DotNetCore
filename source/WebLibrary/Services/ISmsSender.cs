using System.Threading.Tasks;

namespace WebLibrary.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
