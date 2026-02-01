using PawlyPetCare.Application.DTOs;

namespace PawlyPetCare.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserProfileDto?> GetProfileAsync(string email);
        Task<UserProfileDto> UpdateProfileAsync(string email, UpdateProfileDto updateDto);
    }
}
