using Microsoft.EntityFrameworkCore;
using PawlyPetCare.Application.DTOs;
using PawlyPetCare.Application.Interfaces;
using PawlyPetCare.Domain.Entities;
using PawlyPetCare.Infrastructure;

namespace PawlyPetCare.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;

        public AppointmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AppointmentDto> CreateAppointmentAsync(string userEmail, CreateAppointmentDto createDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
            if (user == null) throw new Exception("User not found");

            var appointment = new Appointment
            {
                UserId = user.Id,
                DoctorId = createDto.DoctorId,
                OwnerName = createDto.OwnerName,
                PetName = createDto.PetName,
                Date = createDto.Date,
                Time = createDto.Time,
                Reason = createDto.Reason,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            // Fetch doctor name for DTO
            var doctor = await _context.Doctors.FindAsync(createDto.DoctorId);
            
            return new AppointmentDto
            {
                Id = appointment.Id,
                DoctorId = appointment.DoctorId,
                OwnerName = appointment.OwnerName,
                PetName = appointment.PetName,
                Date = appointment.Date,
                Time = appointment.Time,
                Reason = appointment.Reason,
                Status = appointment.Status,
                DoctorName = doctor?.Name ?? "Unknown Doctor"
            };
        }

        public async Task<List<AppointmentDto>> GetMyAppointmentsAsync(string userEmail)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
            if (user == null) return new List<AppointmentDto>();

            var appointments = await _context.Appointments
                .Where(a => a.UserId == user.Id)
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();

            var appointmentDtos = new List<AppointmentDto>();
            foreach (var appt in appointments)
            {
                var doctor = await _context.Doctors.FindAsync(appt.DoctorId);
                appointmentDtos.Add(new AppointmentDto
                {
                    Id = appt.Id,
                    DoctorId = appt.DoctorId,
                    OwnerName = appt.OwnerName,
                    PetName = appt.PetName,
                    Date = appt.Date,
                    Time = appt.Time,
                    Reason = appt.Reason,
                    Status = appt.Status,
                    DoctorName = doctor?.Name ?? "Unknown Doctor"
                });
            }

            return appointmentDtos;
        }
    }
}
