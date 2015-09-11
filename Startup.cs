using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetBlog.Models;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Data.Entity;

namespace AspNetBlog
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectPostgres = "Host=localhost;Username=postgres;Password=root;Database=asp_net_blog";
            services.AddEntityFramework()
                .AddNpgsql()
                .AddDbContext<BlogDataContext>(options =>
                    options.UseNpgsql(connectPostgres));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
                routes.MapRoute("Defoult",
                "{controller=Home}/{action=Index}/{id?}"));

            app.UseStaticFiles();
        }
    }
}
