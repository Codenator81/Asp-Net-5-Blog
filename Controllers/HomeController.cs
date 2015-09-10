﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AspNetBlog.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetBlog.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var posts = new[] {
                new Post {
                    Title = "Blog Post #1",
                    PostedDate = DateTime.Now,
                    Author = "Jess Chadwick",
                    Body = "This is my first blog post about ASP.NET MVC 6!",
                },
                new Post {
                    Title = "Blog Post #2",
                    PostedDate = DateTime.Now,
                    Author = "Jess Chadwick",
                    Body = "This is my second blog post about ASP.NET MVC 6!",
                },
                new Post {
                    Title = "Blog Post #3",
                    PostedDate = DateTime.Now,
                    Author = "Jess Chadwick",
                    Body = "This is my third blog post about ASP.NET MVC 6!",
                }
            };

            return View(posts);
        }

        public IActionResult Post(long id)
        {
            var post = new Post();

            post.Title = "My Blog Post";
            post.PostedDate = DateTime.Now;
            post.Author = "Alex Poltarjonoks";
            post.Body = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";

            return View(post);
        }
    }
}
