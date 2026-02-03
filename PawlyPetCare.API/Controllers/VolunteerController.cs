using Microsoft.AspNetCore.Mvc;
using PawlyPetCare.Application.Interfaces;
using PawlyPetCare.Domain.Entities;

namespace PawlyPetCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VolunteerController : ControllerBase
    {
        private readonly IVolunteerService _volunteerService;

        public VolunteerController(IVolunteerService volunteerService)
        {
            _volunteerService = volunteerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Volunteer volunteer)
        {
            var created = await _volunteerService.CreateAsync(volunteer);
            return Ok(created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var volunteers = await _volunteerService.GetAllAsync();
            return Ok(volunteers);
        }

        [HttpGet("my-volunteers")]
        public async Task<IActionResult> GetMyVolunteers([FromQuery] string email)
        {
            if (string.IsNullOrEmpty(email)) return BadRequest("Email is required");
            var volunteers = await _volunteerService.GetVolunteersByEmailAsync(email);
            return Ok(volunteers);
        }
    }
}
