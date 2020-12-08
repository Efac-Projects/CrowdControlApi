using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CrowdControl.Data;
using CrowdControl.Models;
using Microsoft.AspNetCore.Identity;

namespace CrowdControl
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
            services.AddDbContext<CrowdDBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("CrowdDBContext")));

            services.AddControllers();
            services.AddControllersWithViews();

            

            var builder = services.AddIdentityCore<AppUser>();
            var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);

            identityBuilder.AddEntityFrameworkStores<CrowdDBContext>();
            identityBuilder.AddSignInManager<SignInManager<AppUser>>();

            var serviceProvider = services.BuildServiceProvider();
            var context = serviceProvider.GetRequiredService<CrowdDBContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            Seed.SeedData(context, userManager).Wait();

            services.AddAuthentication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
