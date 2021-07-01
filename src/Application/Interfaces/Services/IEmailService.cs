using CleanArchitectureTemplate.Application.DTOs.Email.Requests;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
