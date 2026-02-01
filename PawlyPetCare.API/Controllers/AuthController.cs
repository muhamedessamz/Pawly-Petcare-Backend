using Microsoft.AspNetCore.Mvc;
using PawlyPetCare.Application.DTOs;
using PawlyPetCare.Application.Interfaces;

namespace PawlyPetCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try 
            {
                var result = await _authService.LoginAsync(loginDto);
                if (result == null)
                {
                    return Unauthorized(new { message = "Invalid credentials" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                 return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                var result = await _authService.RegisterAsync(registerDto);
                // Return 200/201 but frontend should know redirect to verify
                return Ok(new { message = "Registration successful. Please verify OTP sent to email.", email = result.Email });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto verifyDto)
        {
            var success = await _authService.VerifyOtpAsync(verifyDto);
            if (!success) return BadRequest(new { message = "Invalid or expired OTP." });
            return Ok(new { message = "Account verified successfully." });
        }

        [HttpPost("resend-otp")]
        public async Task<IActionResult> ResendOtp([FromBody] ResendOtpDto resendDto)
        {
            var result = await _authService.ResendOtpAsync(resendDto);
            return Ok(new { message = "OTP resent successfully." });
        }
        
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotDto)
        {
            var result = await _authService.ForgotPasswordAsync(forgotDto);
            return Ok(new { message = "If email exists, OTP sent." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetDto)
        {
            var success = await _authService.ResetPasswordAsync(resetDto);
            if (!success) return BadRequest(new { message = "Invalid OTP or Email." });
            return Ok(new { message = "Password reset successfully." });
        }
    }
}
