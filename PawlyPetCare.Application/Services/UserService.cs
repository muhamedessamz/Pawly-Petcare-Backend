using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PawlyPetCare.Application.DTOs;
using PawlyPetCare.Application.Interfaces;
using PawlyPetCare.Infrastructure;

namespace PawlyPetCare.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public UserService(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<UserProfileDto?> GetProfileAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return null;

            return new UserProfileDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Username = user.Username,
                ProfilePictureUrl = user.ProfilePictureUrl,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                Role = user.Role
            };
        }

        public async Task<UserProfileDto> UpdateProfileAsync(string email, UpdateProfileDto updateDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) throw new Exception("User not found");

            if (!string.IsNullOrEmpty(updateDto.Name)) user.Name = updateDto.Name;
            if (!string.IsNullOrEmpty(updateDto.PhoneNumber)) user.PhoneNumber = updateDto.PhoneNumber;
            if (!string.IsNullOrEmpty(updateDto.Address)) user.Address = updateDto.Address;

            // Handle Profile Picture Upload
            if (updateDto.ProfilePicture != null)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "profiles");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + updateDto.ProfilePicture.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await updateDto.ProfilePicture.CopyToAsync(fileStream);
                }

                // Construct accessible URL (assuming static files are served)
                // We need to ensure Program.cs enables StaticFiles
                user.ProfilePictureUrl = $"/uploads/profiles/{uniqueFileName}";
            }

            await _context.SaveChangesAsync();

            return new UserProfileDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Username = user.Username,
                ProfilePictureUrl = user.ProfilePictureUrl,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                Role = user.Role
            };
        }
    }
}
