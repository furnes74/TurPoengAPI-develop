using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Db.Context;
using Db.Models;
using Microsoft.Extensions.Logging;
using Db.Repository.Interface;
using Db.Repository;

namespace TurPoengAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly TurPoengContext _context;

        private readonly ILogger<PostsController> _logger;
        private readonly IPostRepository _postRepo;

        public PostsController(IPostRepository postRepo, ILogger<PostsController> logger)
        {
            _postRepo = postRepo;
            _logger = logger;
        }


        // GET: api/Posts
        [HttpGet]
        public Post[] Get() 
        {
            return  _postRepo.GetPost();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Post.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostsNearBy(double MinLatitude, double MaxLatitude, double MinLongitude, double maxLongitude)
        {
            //var post = await _context.Post.FindAsync(id);

            //if (post == null)
            //{
            //    return NotFound();
            //}
            return null;
            //return post;
        }



        // PUT: api/Posts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
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

        // POST: api/Posts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            _context.Post.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Post.Remove(post);
            await _context.SaveChangesAsync();

            return post;
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.Id == id);
        }
    }
}
