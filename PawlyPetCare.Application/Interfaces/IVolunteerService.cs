using PawlyPetCare.Domain.Entities;

namespace PawlyPetCare.Application.Interfaces
{
    public interface IVolunteerService
    {
        Task<Volunteer> CreateAsync(Volunteer volunteer);
        Task<IEnumerable<Volunteer>> GetAllAsync();
        Task<IEnumerable<Volunteer>> GetVolunteersByEmailAsync(string email);
    }
}
