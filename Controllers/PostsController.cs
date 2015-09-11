using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AspNetBlog.Models;

namespace AspNetBlog.Controllers
{
    public class PostsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post(long id)
        {
            var post = new Post
            {
                Title = "My Blog Post",
                PostedDate = DateTime.Now,
                Author = "Alex Poltarjonoks",
                Body =
                    "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy " +
                    "eirmod tempor invidunt ut labore et dolore magna aliquyam erat, " +
                    "sed diam voluptua. At vero eos et accusam et justo duo dolores et ea " +
                    "rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem " +
                    "ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                    "sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat," +
                    " sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. " +
                    "Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet." +
                    " Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy " +
                    "eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam " +
                    "voluptua. At vero eos et accusam et justo duo dolores et ea rebum. " +
                    "Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet."
            };

            return View(post);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                return View(post);
            }
            post.PostedDate = DateTime.Now;
            post.Author = User.Identity.Name;

            return View();
        }
    }
}
