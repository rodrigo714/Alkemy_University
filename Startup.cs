using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Expedientes_Goya.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Expedientes_Goya.Models;

namespace Expedientes_Goya
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDefaultIdentity<IdentityExtends>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "Organizaciones",
                    areaName: "Organizaciones",
                    pattern: "{controller=Organizaciones}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "Career",
                    areaName: "Career",
                    pattern: "{controller=Careers}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "Course",
                    areaName: "Course",
                    pattern: "{controller=Courses}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "Inscriptions",
                    areaName: "Inscriptions",
                    pattern: "{controller=Inscriptions}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "Expedientes",
                    areaName: "Expedientes",
                    pattern: "{controller=Expedientes}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
