using Microsoft.EntityFrameworkCore;
using PawlyPetCare.Application.DTOs;
using PawlyPetCare.Application.Interfaces;
using PawlyPetCare.Domain.Entities;
using PawlyPetCare.Infrastructure;

namespace PawlyPetCare.Application.Services
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _context;

        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost)
        {
            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();
            return blogPost;
        }

        public async Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync()
        {
            return await _context.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost?> GetBlogPostByIdAsync(int id)
        {
            return await _context.BlogPosts.FindAsync(id);
        }

        // Admin methods
        public async Task<List<BlogPost>> GetAllBlogsAsync()
        {
            return await _context.BlogPosts.OrderByDescending(b => b.Date).ToListAsync();
        }

        public async Task<BlogPost> CreateBlogAsync(CreateBlogDto dto)
        {
            var blog = new BlogPost
            {
                Title = dto.Title,
                Content = dto.Content,
                Author = dto.Author,
                Image = dto.ImageUrl,
                Date = DateTime.UtcNow
            };

            _context.BlogPosts.Add(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<BlogPost> UpdateBlogAsync(int id, UpdateBlogDto dto)
        {
            var blog = await _context.BlogPosts.FindAsync(id);
            if (blog == null)
            {
                throw new Exception("Blog not found");
            }

            blog.Title = dto.Title;
            blog.Content = dto.Content;
            blog.Author = dto.Author;
            blog.Image = dto.ImageUrl;

            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<bool> DeleteBlogAsync(int id)
        {
            var blog = await _context.BlogPosts.FindAsync(id);
            if (blog == null)
            {
                return false;
            }

            _context.BlogPosts.Remove(blog);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
