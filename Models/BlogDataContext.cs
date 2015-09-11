using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace AspNetBlog.Models
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}
