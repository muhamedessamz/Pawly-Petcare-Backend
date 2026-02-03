using System;

namespace PawlyPetCare.Domain.Entities
{
    public class Volunteer
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Interest { get; set; }
        public string? Experience { get; set; }
        public required string Availability { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
