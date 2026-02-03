using Microsoft.EntityFrameworkCore;
using PawlyPetCare.Application.Interfaces;
using PawlyPetCare.Domain.Entities;
using PawlyPetCare.Infrastructure;

namespace PawlyPetCare.Application.Services
{
    public class PetService : IPetService
    {
        private readonly ApplicationDbContext _context;

        public PetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pet> CreatePetAsync(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return pet;
        }

        public async Task DeletePetAsync(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet != null)
            {
                _context.Pets.Remove(pet);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Pet>> GetAllPetsAsync()
        {
            return await _context.Pets.ToListAsync();
        }

        public async Task<IEnumerable<Pet>> GetApprovedPetsAsync()
        {
            return await _context.Pets.Where(p => p.Status == "Approved").ToListAsync();
        }

        public async Task<IEnumerable<Pet>> GetPendingPetsAsync()
        {
            return await _context.Pets.Where(p => p.Status == "PendingApproval").ToListAsync();
        }

        public async Task<Pet?> GetPetByIdAsync(int id)
        {
            return await _context.Pets.FindAsync(id);
        }

        public async Task ApprovePetAsync(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) throw new Exception("Pet not found");

            pet.Status = "Approved";
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pet>> GetPetsByOwnerEmailAsync(string email)
        {
            return await _context.Pets
                .Where(p => p.OwnerEmail == email)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }
    }
}
