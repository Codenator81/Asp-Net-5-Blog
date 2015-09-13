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
using Microsoft.Framework.Configuration;
using Microsoft.Dnx.Runtime;
using AspNetBlog.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspNetBlog
{
    public class Startup
    {
        public IConfigurationRoot config { get; set; }

        public Startup(IApplicationEnvironment env)
        {
            config = new ConfigurationBuilder(env.ApplicationBasePath)
                .AddEnvironmentVariables()
                .AddJsonFile("config.json")
                .AddJsonFile("config.dev.json", true)
                .AddUserSecrets()
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<AspNetBlog.Models.BlogDataContext>();
            services.AddScoped<AspNetBlog.Models.Identity.IdentityDataContext>();
            services.AddTransient<AspNetBlog.Models.FormattingService>();
            var connectPostgres = "Host=localhost;Username=postgres;Password=root;Database=asp_net_blog";
            var identityConnectionString = "Host=localhost;Username=postgres;Password=root;Database=asp_net_blog_identity";
            services.AddEntityFramework()
                .AddNpgsql()
                .AddDbContext<BlogDataContext>(options =>
                    options.UseNpgsql(connectPostgres))
               .AddDbContext<IdentityDataContext>(dbConfig =>
                    dbConfig.UseNpgsql(identityConnectionString));
            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<IdentityDataContext>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseIdentity();
            var password = config["password"];
            if (config["debug"] == "true")
            {
                app.UseErrorPage();
                app.UseRuntimeInfoPage();
            }
            else
            {
                app.UseErrorHandler("/home/error");
            }

            app.UseMvc(routes =>
                routes.MapRoute("Defoult",
                "{controller=Home}/{action=Index}/{id?}"));

            app.UseStaticFiles();
        }
    }
}
