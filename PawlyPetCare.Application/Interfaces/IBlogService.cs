using PawlyPetCare.Application.DTOs;
using PawlyPetCare.Domain.Entities;

namespace PawlyPetCare.Application.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync();
        Task<BlogPost?> GetBlogPostByIdAsync(int id);
        Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost);
        
        // Admin methods
        Task<List<BlogPost>> GetAllBlogsAsync();
        Task<BlogPost> CreateBlogAsync(CreateBlogDto dto);
        Task<BlogPost> UpdateBlogAsync(int id, UpdateBlogDto dto);
        Task<bool> DeleteBlogAsync(int id);
    }
}
