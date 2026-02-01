using PawlyPetCare.Application.DTOs;
using PawlyPetCare.Domain.Entities;

namespace PawlyPetCare.Application.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor?> GetDoctorByIdAsync(int id);
        Task<Doctor> CreateDoctorAsync(CreateDoctorDto createDoctorDto);
        Task DeleteDoctorAsync(int id);
    }
}
