namespace PawlyPetCare.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string Category { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public double Rating { get; set; } = 0;
        public int ReviewCount { get; set; } = 0;
    }
}
