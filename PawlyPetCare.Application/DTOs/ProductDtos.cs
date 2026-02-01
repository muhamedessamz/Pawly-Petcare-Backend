namespace PawlyPetCare.Application.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; } // Food, Accessories, Houses, Toys, Healthcare, Grooming
        public string PetType { get; set; } // Dog, Cat, Both
    }

    public class UpdateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string PetType { get; set; }
    }

    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string? PetType { get; set; }
        public string? ImageUrl { get; set; }
    }
}
