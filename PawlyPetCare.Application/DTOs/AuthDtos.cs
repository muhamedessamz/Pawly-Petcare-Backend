using System.ComponentModel.DataAnnotations;

namespace PawlyPetCare.Application.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }

    public class RegisterDto
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(6)]
        public required string Password { get; set; }
        
        [Compare("Password")]
        public required string ConfirmPassword { get; set; }
    }

    public class AuthResponseDto
    {
        public required string Token { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
        public string? Name { get; set; }
    }

    public class VerifyOtpDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string OtpCode { get; set; }
    }

    public class ResendOtpDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
    
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }

    public class ResetPasswordDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        
        [Required]
        public required string OtpCode { get; set; } // We verify OTP again before resetting

        [Required]
        [MinLength(6)]
        public required string NewPassword { get; set; }
    }
}
