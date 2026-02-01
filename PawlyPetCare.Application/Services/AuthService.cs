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

        public async Task<AuthResponseDto?> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            if (user == null || user.PasswordHash != loginDto.Password) // Simple check, use hashing in prod
            {
                return null;
            }

            return new AuthResponseDto
            {
                Token = "mock-jwt-token-" + Guid.NewGuid(), // Replace with real JWT generation
                Email = user.Email,
                Role = user.Role,
                Name = user.Name
            };
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            var user = new User
            {
                Email = registerDto.Email,
                PasswordHash = registerDto.Password, // Hash this!
                Name = registerDto.Name,
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Token = "mock-jwt-token-" + Guid.NewGuid(),
                Email = user.Email,
                Role = user.Role,
                Name = user.Name
            };
        }
    }
}
