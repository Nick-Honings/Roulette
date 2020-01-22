using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roulette.ASP.NETCore.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataAccesFactory.Factory;
using TestDataAccesFactory;
using NetCore.AutoRegisterDi;
using System.Reflection;
using TestDataAccesFactory.Interfaces;

namespace Roulette.ASP.NETCore
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

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //var assembly = Assembly.GetAssembly(typeof(MySqlRepository));

            //services.RegisterAssemblyPublicNonGenericClasses(assembly)
            //     .Where(x => x.Name.EndsWith("Repository"))
            //         .AsPublicImplementedInterfaces();
            services.AddScoped<IAdminRepository>(s => new MySqlRepository("DemoDB"));
            services.AddScoped<IUserContainerRepository>(s => new MySqlRepository("DemoDB"));
            services.AddScoped<IBetRepository>(s => new MySqlRepository("DemoDB"));


            //services.AddScoped<IAdminRepository, MySqlRepository>();
            //services.AddScoped<IUserContainerRepository, MySqlRepository>();
            //services.AddScoped<IBetRepository, MySqlRepository>();
            //services.AddScoped<IRepository>(RepositoryFactory.Create("inmem")>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Room}/{action=Index}/{id?}");
            });
        }
    }
}
