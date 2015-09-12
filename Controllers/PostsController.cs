using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AspNetBlog.Models;
using Microsoft.Data.Entity;

namespace AspNetBlog.Controllers
{
    public class PostsController : Controller
    {
        [FromServices]
        private BlogDataContext Db { get; set; }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post(long id)
        {

            var post = Db.Posts.SingleOrDefault(x => x.Id == id);

            return View(post);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }
            post.PostedDate = DateTime.Now;
            post.Author = User.Identity.Name;

            Db.Posts.Add(post);
            await Db.SaveChangesAsync();

            return RedirectToAction("Post", new {id = post.Id});
        }
    }
}
