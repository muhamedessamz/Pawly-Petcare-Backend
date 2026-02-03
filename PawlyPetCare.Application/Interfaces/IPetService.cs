using PawlyPetCare.Domain.Entities;

namespace PawlyPetCare.Application.Interfaces
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> GetAllPetsAsync();
        Task<IEnumerable<Pet>> GetApprovedPetsAsync();
        Task<IEnumerable<Pet>> GetPendingPetsAsync();
        Task<Pet?> GetPetByIdAsync(int id);
        Task<Pet> CreatePetAsync(Pet pet);
        Task ApprovePetAsync(int id);
        Task DeletePetAsync(int id);
        Task<IEnumerable<Pet>> GetPetsByOwnerEmailAsync(string email);
    }
}
