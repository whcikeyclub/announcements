using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RajatPatwari.Announcements
{
    public sealed class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public void ConfigureServices(IServiceCollection services) =>
            services.AddControllersWithViews();

        public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }
            else
            {
                application.UseExceptionHandler("/Home/Error");
                application.UseHsts();
            }

            application.UseHttpsRedirection();
            application.UseStaticFiles();

            application.UseRouting();

            application.UseAuthorization();

            application.UseEndpoints(endpoints =>
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}")
            );
        }
    }
}