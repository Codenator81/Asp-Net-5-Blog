using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AspNetBlog.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetBlog.Api
{
    [Route("api/posts/{postId:long}/comments")]
    public class CommentsController : Controller
    {
        private readonly BlogDataContext _db;

        public CommentsController(BlogDataContext db)
        {

            _db = db;
        }
        // GET: "api/posts/postId/comments"
        [HttpGet]
        public IQueryable<Comment> Get(long postId)
        {
            return _db.Comments.Where(x => x.PostId == postId);
        }

        // POST "api/posts/postId/comments"
        [HttpPost]
        public async Task<Comment> Post(long postId, [FromBody]Comment comment)
        {
            comment.PostId = postId;
            comment.Author = User.Identity.Name;
            comment.PostedDate = DateTime.Now;

            _db.Comments.Add(comment);
            await _db.SaveChangesAsync();

            return comment;
        }
    }
}
