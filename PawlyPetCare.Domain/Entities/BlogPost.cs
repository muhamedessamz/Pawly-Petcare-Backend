using System;

namespace PawlyPetCare.Domain.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string Author { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string? Image { get; set; }
        public string? Category { get; set; }
        public string? Excerpt { get; set; }
    }
}
