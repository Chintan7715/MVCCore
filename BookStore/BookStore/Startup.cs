using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace BookStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(option => option.UseSqlServer("Server=DESKTOP-0SGCR42\\SQLEXPRESS; Database=DB_BookStore; user id=sa; password=4ever; trusted_connection=true; multipleactiveresultsets=true;"));
            services.AddControllersWithViews();
            //services.AddMvc();
            //Below service for to modify the razor page at compile time, 
            //but only on development time thats why we added the condition
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
            //Uncomment below three line if you want to disable the disable client side validation
            //.AddViewOptions(option => 
            //{
            //    option.HtmlHelperOptions.ClientValidationEnabled = false;
            //});
#endif
            services.AddScoped<BookRepository, BookRepository>();
            services.AddScoped<LanguageRepository, LanguageRepository>();
        }        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //When static file is in wwwwroot folder
            app.UseStaticFiles();
            //When static file is out of wwwwroot folder
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory() + "/MyStaticFiles")),
            //    RequestPath = "/MyStaticFiles"
            //}); 

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync(env.EnvironmentName);
            //    });
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute(
                //    name: "Default",
                //    pattern: "BookStore/{controller=Home}/{action=Index}/{id?}");


                //endpoints.Map("/", async context =>
                //{
                //    await context.Response.WriteAsync("I'm Shaurya!");
                //});

                //endpoints.Map("/", async context => await context.Response.WriteAsync("I am Sehu"));

                //-------MapGet
                //endpoints.MapGet("/shaurya", async context =>
                //{
                //    await context.Response.WriteAsync("I'm Shaurya!");
                //});
            });
        }
    }
}
