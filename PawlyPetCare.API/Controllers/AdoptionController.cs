using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawlyPetCare.Domain.Entities;
using PawlyPetCare.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PawlyPetCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdoptionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdoptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] AdoptionRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request.");

            // Check if user already requested this pet
            var existingRequest = await _context.AdoptionRequests
                .FirstOrDefaultAsync(r => r.PetId == request.PetId && r.UserId == request.UserId);

            if (existingRequest != null)
                return BadRequest("You have already submitted a request for this pet.");

            request.RequestDate = DateTime.UtcNow;
            request.Status = "Pending";

            _context.AdoptionRequests.Add(request);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Adoption request submitted successfully!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequests()
        {
            var requests = await _context.AdoptionRequests
                .Include(r => r.Pet)
                .Include(r => r.User)
                .OrderByDescending(r => r.RequestDate)
                .ToListAsync();

            return Ok(requests);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserRequests(int userId)
        {
            var requests = await _context.AdoptionRequests
                .Include(r => r.Pet)
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.RequestDate)
                .ToListAsync();

            return Ok(requests);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateAdoptionStatusDto statusDto)
        {
             var request = await _context.AdoptionRequests.FindAsync(id);
             if (request == null)
                 return NotFound("Request not found.");

             request.Status = statusDto.Status;
             await _context.SaveChangesAsync();
             
             // If approved, verify if we should mark the pet as 'Adopted' automatically or keep it manual.
             // For now, let's keep it simple.

             return Ok(new { message = $"Request {statusDto.Status} successfully." });
        }
    }

    public class UpdateAdoptionStatusDto
    {
        public string Status { get; set; }
    }
}
