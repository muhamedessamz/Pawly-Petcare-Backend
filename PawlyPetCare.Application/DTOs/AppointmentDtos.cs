using System;

namespace PawlyPetCare.Application.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string OwnerName { get; set; }
        public string PetName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string DoctorName { get; set; } // Enriched
    }

    public class CreateAppointmentDto
    {
        public int DoctorId { get; set; }
        public string OwnerName { get; set; }
        public string PetName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Reason { get; set; }
    }
}
