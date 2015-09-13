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
   

    public IQueryable<ArchivedPostsSummary> GetArchivedPosts()
    {
        return
            Posts
                .GroupBy(x => new { x.PostedDate.Year, x.PostedDate.Month })
                .Select(group => new ArchivedPostsSummary
                {
                    Count = group.Count(),
                    Year = group.Key.Year,
                    Month = group.Key.Month,
                });
    }
    }
}
