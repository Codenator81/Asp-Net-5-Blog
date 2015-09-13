using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AspNetBlog.Models;
using Microsoft.Data.Entity;
using Newtonsoft.Json;
using Microsoft.AspNet.Authorization;

namespace AspNetBlog.Controllers
{
    public class PostsController : Controller
    {
        readonly BlogDataContext _dataContext;
        public PostsController(BlogDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post(long id)
        {

            var post = _dataContext.Posts.SingleOrDefault(x => x.Id == id);

            return View(post);
        }

        [Route("posts/{year:int}/{month:int}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = _dataContext.Posts.SingleOrDefault(
                x => x.PostedDate.Year == year && x.PostedDate.Month == month
                     && x.Key == key.ToLower());

            return View(post);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }
            post.PostedDate = DateTime.Now;
            post.Author = User.Identity.Name;

            _dataContext.Posts.Add(post);
            await _dataContext.SaveChangesAsync();

            return RedirectToAction("Post", new { post.PostedDate.Year, post.PostedDate.Month, post.Key });
        }
    }
}
