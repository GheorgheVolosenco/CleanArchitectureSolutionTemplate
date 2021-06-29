using System.ComponentModel.DataAnnotations;

namespace CarDataPlatformIngestor.Application.DTOs.Account.Requests
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
