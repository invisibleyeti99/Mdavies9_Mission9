using Mdavies9_Mission9.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mdavies9_Mission9
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }

        public Startup (IConfiguration temp)
        {
            Configuration = temp; 
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BookstoreContext>(options=>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookDBConnection"]);
            }
            );
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {//Category{bookCat} see if this works in patterns
                endpoints.MapControllerRoute("Catpage",
                    "{bookCat}/Page{pageNum}",
                    new { Controller = "Home", action = "Index" });


                endpoints.MapControllerRoute(name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new
                    {
                        Controller = "Home",
                        action = "Index",
                        pageNum = 1 
                    });

                endpoints.MapControllerRoute("Category",
                    "{bookCat}",
                    new { Controller = "Home", action = "Index", pageNum = 1 });

                

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

        }
    }
}
