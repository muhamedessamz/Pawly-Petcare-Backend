using PawlyPetCare.Application.DTOs;

namespace PawlyPetCare.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginAsync(LoginDto loginDto);
        Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
        
        // New Auth Flows
        Task<bool> VerifyOtpAsync(VerifyOtpDto verifyDto);
        Task<string> ResendOtpAsync(ResendOtpDto resendDto);
        Task<string> ForgotPasswordAsync(ForgotPasswordDto forgotDto);
        Task<bool> ResetPasswordAsync(ResetPasswordDto resetDto);
    }
}
