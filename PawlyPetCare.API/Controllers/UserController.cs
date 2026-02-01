using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawlyPetCare.Application.DTOs;
using PawlyPetCare.Application.Interfaces;
using System.Security.Claims; // Important for User.Identity

namespace PawlyPetCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // We need to extract email from the token normally, but for now enforcing param or trusting frontend
        // Ideally we use [Authorize] and User.FindFirst(ClaimTypes.Email)
        
        [HttpPost("profile")] // Using POST to fetch by email for security if we don't have full JWT claims setup verified
        public async Task<IActionResult> GetProfile([FromBody] ForgotPasswordDto dto) // Reusing Dto with Email
        {
             var profile = await _userService.GetProfileAsync(dto.Email);
             if (profile == null) return NotFound();
             return Ok(profile);
        }

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile([FromForm] UpdateProfileDto updateDto, [FromQuery] string email)
        {
            try
            {
                var profile = await _userService.UpdateProfileAsync(email, updateDto);
                return Ok(profile);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
