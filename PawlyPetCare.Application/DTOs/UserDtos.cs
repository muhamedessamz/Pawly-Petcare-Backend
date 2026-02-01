using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PawlyPetCare.Application.DTOs
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string Role { get; set; }
    }

    public class UpdateProfileDto
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public IFormFile? ProfilePicture { get; set; }
    }
}
