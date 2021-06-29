using CarDataPlatformIngestor.Application.DTOs.Account.Requests;
using CarDataPlatformIngestor.Application.DTOs.Account.Responses;
using CarDataPlatformIngestor.Application.Wrappers;
using System.Threading.Tasks;

namespace CarDataPlatformIngestor.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);

        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);

        Task<Response<string>> ConfirmEmailAsync(string userId, string code);

        Task ForgotPassword(ForgotPasswordRequest model, string origin);

        Task<Response<string>> ResetPassword(ResetPasswordRequest model);
    }
}
