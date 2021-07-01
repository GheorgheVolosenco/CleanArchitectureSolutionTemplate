using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureTemplate.Application.DTOs.Account.Requests
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
