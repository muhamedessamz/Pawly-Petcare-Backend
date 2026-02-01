namespace PawlyPetCare.Application.DTOs
{
    public class CreateBlogDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string? ImageUrl { get; set; }
    }

    public class UpdateBlogDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string? ImageUrl { get; set; }
    }
}
