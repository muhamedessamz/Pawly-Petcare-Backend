using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawlyPetCare.Infrastructure;

namespace PawlyPetCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            var stats = new
            {
                TotalProducts = await _context.Products.CountAsync(),
                TotalDoctors = await _context.Doctors.CountAsync(),
                TotalUsers = await _context.Users.CountAsync(),
                TotalOrders = 150 // Mock for now
            };

            return Ok(stats);
        }
    }
}
