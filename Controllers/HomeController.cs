using System;
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
        private readonly BlogDataContext _db;

        public HomeController(BlogDataContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var posts =
                _db.Posts
                    .OrderByDescending(x => x.PostedDate)
                    .ToArray();
            return View(posts);
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult CauseAnError()
        {
            throw new Exception("Error!");
        }
    }
}
