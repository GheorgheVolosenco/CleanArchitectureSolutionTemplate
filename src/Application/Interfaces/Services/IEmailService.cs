using CarDataPlatformIngestor.Application.DTOs.Email.Requests;
using System.Threading.Tasks;

namespace CarDataPlatformIngestor.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
