using Microsoft.AspNetCore.Mvc;
using PawlyPetCare.Application.Interfaces;
using PawlyPetCare.Domain.Entities;

namespace PawlyPetCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pets = await _petService.GetAllPetsAsync();
            return Ok(pets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pet = await _petService.GetPetByIdAsync(id);
            if (pet == null) return NotFound();
            return Ok(pet);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Pet pet)
        {
           var createdPet = await _petService.CreatePetAsync(pet);
           return CreatedAtAction(nameof(GetById), new { id = createdPet.Id }, createdPet);
        }
    }
}
