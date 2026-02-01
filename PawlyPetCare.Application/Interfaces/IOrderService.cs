using System.Collections.Generic;
using System.Threading.Tasks;
using PawlyPetCare.Application.DTOs;

namespace PawlyPetCare.Application.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(string userEmail, CreateOrderDto createDto);
        Task<List<OrderDto>> GetMyOrdersAsync(string userEmail);
    }
}
