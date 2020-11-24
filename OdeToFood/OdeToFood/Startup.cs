using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OdeToFood.Data;

namespace OdeToFood
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {//to describe DbContext that the app will use
            services.AddDbContextPool<OdeToFoodDbContext>(options =>
            {
                //i want to use sql server with this connection string
                options.UseSqlServer(Configuration.GetConnectionString("OdeToFoodDb"));
            });
            /////////////////////
            //Add List Of Table
            //services.AddSingleton<IRestaurantData,InMemoryRestaurantData>();
            //Add data base to Project instead of Memory Data
            //Singlton will be very bad for this Application
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
            //////////////////////////////
            services.AddRazorPages();
            ////////////////////////////
            // for aspnetcore3.0+

            //services.AddRazorPages();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
       //control my asp.net core application
       //including if am going to use wwwroot folder not 
        public void Configure(IApplicationBuilder app,
                              IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //first piece of middle wear
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //create middle wear
            app.Use(SayHelloMiddleware);
            /////////
            app.UseHttpsRedirection();
            //this for request jquery.js that find file of file system inside folder
            //return that file from the web server
            app.UseStaticFiles();
            /////////////////////////
            app.UseNodeModules(null, "/node_modules");
            

           
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                /////////////
                // for aspnetcore3.0+
                endpoints.MapControllers();
            });

            
            //////////////////////////
            app.UseCookiePolicy();
            //app.UseMvc();


        }
        // hello middle were
        private RequestDelegate SayHelloMiddleware(RequestDelegate next)
        {
            return async context =>
            {
                //path to get Hello world!
                if(context.Request.Path.StartsWithSegments("/hello"))
                { await context.Response.WriteAsync("Hello. World!");}
                else
                {
                   await next(context);
                }
            };
        }
    }
}
