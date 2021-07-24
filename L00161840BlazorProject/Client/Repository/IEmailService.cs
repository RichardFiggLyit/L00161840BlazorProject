using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public interface IEmailService
    {
        Task SendEmail(string from, string to, string subject, string body);
    }
}