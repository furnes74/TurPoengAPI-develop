using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Db.Repository.Interface;
using Db.ViewModels;

namespace TurPoengAPI.Api.Controllers
{
    public class PostsController : ApiControllerBase
    {
        private readonly IPostRepository _postRepo;

        public PostsController(IPostRepository postRepo, ILogger<PostsController> logger) : base(logger)
        {
            _postRepo = postRepo;
        }

        [HttpGet("get")]
        public PostVm[] Get() 
        {
            return  _postRepo.GetAllPostVms();
        }

        [HttpGet("getpost/{id}")]
        public PostVm GetPost(int id)
        {
            return _postRepo.GetPostVm(id);
        }

        [HttpPost("SearchPostsNearBy")]
        public PostVm[] SearchPostsNearBy(SearchPostVm searchVm)
        {
            return _postRepo.SearchPostNearBy(searchVm);
        }

        [HttpPost("SuggestNewPost")]
        public bool SuggestNewPost(PostVm newPostVm)
        {
            return _postRepo.AddOrUpdatePost(newPostVm);
        }


        //// PUT: api/Posts/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPost(int id, Post post)
        //{
        //    throw new NotImplementedException();
        //    //if (id != post.Id)
        //    //{
        //    //    return BadRequest();
        //    //}

        //    //_context.Entry(post).State = EntityState.Modified;

        //    //try
        //    //{
        //    //    await _context.SaveChangesAsync();
        //    //}
        //    //catch (DbUpdateConcurrencyException)
        //    //{
        //    //    if (!PostExists(id))
        //    //    {
        //    //        return NotFound();
        //    //    }
        //    //    else
        //    //    {
        //    //        throw;
        //    //    }
        //    //}

        //    //return NoContent();
        //}

        //// POST: api/Posts
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Post>> PostPost(Post post)
        //{
        //    _context.Post.Add(post);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPost", new { id = post.Id }, post);
        //}

        //// DELETE: api/Posts/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Post>> DeletePost(int id)
        //{
        //    var post = await _context.Post.FindAsync(id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Post.Remove(post);
        //    await _context.SaveChangesAsync();

        //    return post;
        //}

        //private bool PostExists(int id)
        //{
        //    return _context.Post.Any(e => e.Id == id);
        //}
    }
}
