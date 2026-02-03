using Microsoft.EntityFrameworkCore;
using PawlyPetCare.Application.DTOs;
using PawlyPetCare.Application.Interfaces;
using PawlyPetCare.Domain.Entities;
using PawlyPetCare.Infrastructure;

namespace PawlyPetCare.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Helper to send email
        private async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var fromEmail = "kjo650636@gmail.com";
                var appPassword = "maukfpfrwmjvyblt"; // App Password

                using var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential(fromEmail, appPassword),
                    EnableSsl = true,
                };

                var mailMessage = new System.Net.Mail.MailMessage
                {
                    From = new System.Net.Mail.MailAddress(fromEmail, "Pawly PetCare"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EMAIL ERROR] Failed to send email: {ex.Message}");
            }
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            if (user == null || user.PasswordHash != loginDto.Password) // Simple check
            {
                return null;
            }

            if (!user.IsVerified)
            {
                throw new Exception("Account not verified. Please verify your email.");
            }

            return new AuthResponseDto
            {
                Token = "mock-jwt-token-" + Guid.NewGuid(),
                Email = user.Email,
                Role = user.Role,
                Name = user.Name,
                Username = user.Username,
                ProfilePictureUrl = user.ProfilePictureUrl
            };
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == registerDto.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists.");
            }

            // Generate OTP
            var otp = new Random().Next(100000, 999999).ToString();

            // Generate Unique Username
            string baseUsername = registerDto.Name.Replace(" ", "").ToLower();
            string username = baseUsername;
            int counter = 1;
            while (await _context.Users.AnyAsync(u => u.Username == username))
            {
                username = $"{baseUsername}{counter}";
                counter++;
            }

            var user = new User
            {
                Email = registerDto.Email,
                PasswordHash = registerDto.Password,
                Name = registerDto.Name,
                Username = username,
                Role = "User",
                IsVerified = false,
                OtpCode = otp,
                OtpExpiration = DateTime.UtcNow.AddMinutes(15)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Send Real Email
            var subject = "Welcome to Pawly - Verify Your Email";
            var body = $@"
                <div style='font-family: Arial, sans-serif; padding: 20px; color: #333;'>
                    <h2 style='color: #2ecc71;'>Welcome to Pawly! 🐾</h2>
                    <p>Thanks for joining the family. To complete your registration, please verify your email address.</p>
                    <div style='background: #f0fdf4; padding: 15px; border-radius: 10px; margin: 20px 0; text-align: center;'>
                        <span style='font-size: 24px; font-weight: bold; letter-spacing: 5px; color: #15803d;'>{otp}</span>
                    </div>
                    <p>This code will expire in 15 minutes.</p>
                </div>";
            
            await SendEmailAsync(user.Email, subject, body);

            return new AuthResponseDto
            {
                Token = "pending-verification", 
                Email = user.Email,
                Role = user.Role,
                Name = user.Name,
                Username = username
            };
        }

        public async Task<bool> VerifyOtpAsync(VerifyOtpDto verifyDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == verifyDto.Email);
            if (user == null) return false;

            if (user.OtpCode == verifyDto.OtpCode && user.OtpExpiration > DateTime.UtcNow)
            {
                user.IsVerified = true;
                user.OtpCode = null;
                user.OtpExpiration = null;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<string> ResendOtpAsync(ResendOtpDto resendDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == resendDto.Email);
            if (user == null) return "User not found";

            var otp = new Random().Next(100000, 999999).ToString();
            user.OtpCode = otp;
            user.OtpExpiration = DateTime.UtcNow.AddMinutes(15);
            
            await _context.SaveChangesAsync();
            
            // Send Real Email
            var subject = "Pawly PetCare - New Verification Code";
            var body = $@"
                <div style='font-family: Arial, sans-serif; padding: 20px; color: #333;'>
                    <h2>New Verification Code</h2>
                    <p>You requested a new OTP code.</p>
                    <div style='background: #f0fdf4; padding: 15px; border-radius: 10px; margin: 20px 0; text-align: center;'>
                        <span style='font-size: 24px; font-weight: bold; letter-spacing: 5px; color: #15803d;'>{otp}</span>
                    </div>
                </div>";
            await SendEmailAsync(user.Email, subject, body);

            return otp;
        }

        public async Task<string> ForgotPasswordAsync(ForgotPasswordDto forgotDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == forgotDto.Email);
            if (user == null) return "User not found"; // Or generic message for security

            var otp = new Random().Next(100000, 999999).ToString();
            user.OtpCode = otp;
            user.OtpExpiration = DateTime.UtcNow.AddMinutes(15);
            
            await _context.SaveChangesAsync();

            // Send Real Email
            var subject = "Pawly PetCare - Reset Password Request";
            var body = $@"
                <div style='font-family: Arial, sans-serif; padding: 20px; color: #333;'>
                    <h2>Reset Your Password 🔒</h2>
                    <p>We received a request to reset your password. Use the code below:</p>
                    <div style='background: #fff0f0; padding: 15px; border-radius: 10px; margin: 20px 0; text-align: center;'>
                         <span style='font-size: 24px; font-weight: bold; letter-spacing: 5px; color: #e11d48;'>{otp}</span>
                    </div>
                    <p>If you didn't request this, you can safely ignore this email.</p>
                </div>";
            await SendEmailAsync(user.Email, subject, body);

            return "OTP sent";
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDto resetDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == resetDto.Email);
            if (user == null) return false;

            if (user.OtpCode == resetDto.OtpCode && user.OtpExpiration > DateTime.UtcNow)
            {
                user.PasswordHash = resetDto.NewPassword;
                user.OtpCode = null;
                user.OtpExpiration = null;
                user.IsVerified = true; // Auto verify if they reset password successfully via OTP
                
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
