using System.Collections.Generic;
using System.Threading.Tasks;
using PawlyPetCare.Application.DTOs;

namespace PawlyPetCare.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentDto> CreateAppointmentAsync(string userEmail, CreateAppointmentDto createDto);
        Task<List<AppointmentDto>> GetMyAppointmentsAsync(string userEmail);
    }
}
