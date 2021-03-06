using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace stackoverflow
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
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSession();
        }
    
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

//            app.UseHttpsRedirection();
            app.UseStaticFiles();
//            app.UseCookiePolicy();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
                routes.MapRoute(
                    name: "AddQuestion",
                    template: "{controller=AddQuestion}/{action=Index}");
                routes.MapRoute(
                    name: "Login",
                    template: "{controller=Login}/{action=Index}");
                routes.MapRoute(
                    name: "Profile",
                    template: "{controller=Profile}/{action=Index}");
                routes.MapRoute(
                    name: "Question",
                    template: "{controller=Question}/{action=Index}/{id}");
                routes.MapRoute(
                    name: "SignUp",
                    template: "{controller=SignUp}/{action=Index}");
                routes.MapRoute(
                    name: "Logout",
                    template: "{controller=Logout}/{action=Index}");
                routes.MapRoute(
                    name: "LikeQuestion",
                    template: "{controller=LikeQuestion}/{action=Index}");
                routes.MapRoute(
                    name: "LikeAnswer",
                    template: "{controller=LikeAnswer}/{action=Index}");
                routes.MapRoute(
                    name: "Search",
                    template: "{controller=Search}/{action=Index}");

            });
        }
    }
}
