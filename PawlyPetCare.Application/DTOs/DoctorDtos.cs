namespace PawlyPetCare.Application.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Specialty { get; set; }
        public string? Image { get; set; }
        public double Rating { get; set; }
        public required string Location { get; set; }
        public string? Availability { get; set; }
        public int ExperienceYears { get; set; }
    }

    public class CreateDoctorDto
    {
        public required string Name { get; set; }
        public required string Specialty { get; set; }
        public string? Image { get; set; }
        public string? Location { get; set; }
        public string? Availability { get; set; }
        public int ExperienceYears { get; set; }
    }
}
