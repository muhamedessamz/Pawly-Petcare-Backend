using Microsoft.AspNetCore.Mvc;
using PawlyPetCare.Application.DTOs;
using PawlyPetCare.Application.Interfaces;

namespace PawlyPetCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentDto createDto)
        {
            // In a real app, user email would come from Claims (User.Identity.Name)
            // For now, we'll assume it's passed or handled, but let's require authentication header logic ideally.
            // But to simplify matching previous patterns, let's look for user email in a header or body?
            // Actually, best to pass email in DTO or Query for this "simple" auth version we have.
            // Let's assume frontend passes email in a custom header 'X-User-Email' if we don't have full JWT claims setup verified.
            // Or simpler: let's require it in the query string like /profile?email=... for consistency with user controller?
            // No, specific resource creation usually has body.
            // Let's expect 'UserEmail' in DTO? No, polluting DTO.
            // Use Header 'X-User-Email'.
            
            if (!Request.Headers.TryGetValue("X-User-Email", out var userEmail))
            {
                return Unauthorized("User email header missing");
            }

            try
            {
                var result = await _appointmentService.CreateAppointmentAsync(userEmail.ToString(), createDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("my-appointments")]
        public async Task<IActionResult> GetMyAppointments([FromQuery] string email)
        {
             try
            {
                var result = await _appointmentService.GetMyAppointmentsAsync(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
             try
            {
                var result = await _appointmentService.GetAllAppointmentsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateStatusDto dto)
        {
             try
            {
                var result = await _appointmentService.UpdateStatusAsync(id, dto.Status);
                if (!result) return NotFound();
                return Ok(new { message = "Status updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class UpdateStatusDto
    {
        public string Status { get; set; }
    }
}
