using System;

namespace PawlyPetCare.Domain.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; } // Dog, Cat, etc.
        public string? Breed { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; } // Male, Female
        public string? Size { get; set; } // Small, Medium, Large
        public string? Location { get; set; }
        public string? Image { get; set; }
        public string Status { get; set; } = "PendingApproval"; // PendingApproval, Approved, Adopted, Rejected
        public string? Description { get; set; }
        public string? Traits { get; set; } // Comma separated: Playful, Energetic, etc.
        public string? Weight { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
