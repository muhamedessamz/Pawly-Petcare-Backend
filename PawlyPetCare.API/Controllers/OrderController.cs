using Microsoft.AspNetCore.Mvc;
using PawlyPetCare.Application.DTOs;
using PawlyPetCare.Application.Interfaces;

namespace PawlyPetCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto createDto)
        {
            if (!Request.Headers.TryGetValue("X-User-Email", out var userEmail))
            {
                return Unauthorized("User email header missing");
            }

            try
            {
                var result = await _orderService.CreateOrderAsync(userEmail.ToString(), createDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("my-orders")]
        public async Task<IActionResult> GetMyOrders([FromQuery] string email)
        {
             try
            {
                var result = await _orderService.GetMyOrdersAsync(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
