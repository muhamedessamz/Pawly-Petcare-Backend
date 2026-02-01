using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawlyPetCare.Domain.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int DoctorId { get; set; }

        public required string OwnerName { get; set; }
        public required string PetName { get; set; }
        public required string Date { get; set; }
        public required string Time { get; set; }
        public required string Reason { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Confirmed, Completed, Cancelled
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties if needed later
        // public User User { get; set; }
        // public Doctor Doctor { get; set; }
    }
}
