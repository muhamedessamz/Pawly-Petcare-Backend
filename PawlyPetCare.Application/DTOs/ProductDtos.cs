namespace PawlyPetCare.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string Category { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
    }

    public class CreateProductDto
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string Category { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
    }

    public class UpdateProductDto
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Category { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int? Stock { get; set; }
    }
}
