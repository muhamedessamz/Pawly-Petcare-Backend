using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PawlyPetCare.Domain.Entities
{
    public class Clinic
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
