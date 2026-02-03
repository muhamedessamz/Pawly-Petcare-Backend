using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawlyPetCare.Domain.Entities
{
    public class AdoptionRequest
    {
        public int Id { get; set; }

        public int PetId { get; set; }
        [ForeignKey("PetId")]
        public virtual Pet Pet { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public string? Message { get; set; }
    }
}
