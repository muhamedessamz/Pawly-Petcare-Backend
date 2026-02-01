using PawlyPetCare.Domain.Entities;

namespace PawlyPetCare.Application.Interfaces
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> GetAllPetsAsync();
        Task<Pet?> GetPetByIdAsync(int id);
        Task<Pet> CreatePetAsync(Pet pet);
        Task DeletePetAsync(int id);
    }
}
