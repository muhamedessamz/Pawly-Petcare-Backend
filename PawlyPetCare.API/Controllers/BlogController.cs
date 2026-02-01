using Microsoft.AspNetCore.Mvc;
using PawlyPetCare.Application.Interfaces;
using PawlyPetCare.Domain.Entities;

namespace PawlyPetCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _blogService.GetAllBlogPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _blogService.GetBlogPostByIdAsync(id);
            if (post == null) return NotFound();
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BlogPost blogPost)
        {
            var createdPost = await _blogService.CreateBlogPostAsync(blogPost);
            return Ok(createdPost);
        }
    }
}
