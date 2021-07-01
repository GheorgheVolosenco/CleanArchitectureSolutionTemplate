using CleanArchitectureTemplate.Application.DTOs.Account.Requests;
using CleanArchitectureTemplate.Application.DTOs.Account.Responses;
using CleanArchitectureTemplate.Application.Wrappers;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Interfaces.Services
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
