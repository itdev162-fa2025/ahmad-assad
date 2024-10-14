using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ahmad.Assad.Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly DataContext _context;

        public PostsController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all posts
        /// </summary>
        /// <returns>A list of all posts</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific post by its ID
        /// </summary>
        /// <param name="id">The ID of the post to retrieve</param>
        /// <returns>The requested post or NotFound if not found</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            
            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        /// <summary>
        /// Creates a new post
        /// </summary>
        /// <param name="post">The post data to create</param>
        /// <returns>The created post</returns>
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }

        /// <summary>
        /// Updates an existing post
        /// </summary>
        /// <param name="id">The ID of the post to update</param>
        /// <param name="post">The updated post data</param>
        /// <returns>No content if successful, or NotFound if the post doesn't exist</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(Guid id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool PostExists(Guid id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
