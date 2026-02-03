using Microsoft.EntityFrameworkCore;
using PawlyPetCare.Application.Interfaces;
using PawlyPetCare.Domain.Entities;
using PawlyPetCare.Infrastructure;

namespace PawlyPetCare.Application.Services
{
    public class VolunteerService : IVolunteerService
    {
        private readonly ApplicationDbContext _context;

        public VolunteerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Volunteer> CreateAsync(Volunteer volunteer)
        {
            _context.Volunteers.Add(volunteer);
            await _context.SaveChangesAsync();
            return volunteer;
        }

        public async Task<IEnumerable<Volunteer>> GetAllAsync()
        {
            return await _context.Volunteers.OrderByDescending(v => v.CreatedAt).ToListAsync();
        }

        public async Task<IEnumerable<Volunteer>> GetVolunteersByEmailAsync(string email)
        {
            return await _context.Volunteers
                .Where(v => v.Email == email)
                .OrderByDescending(v => v.CreatedAt)
                .ToListAsync();
        }
    }
}
