using Application.Models.Mail;
using System.Threading.Tasks;

namespace Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}