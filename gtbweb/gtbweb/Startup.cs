using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gtbweb.Data;
using gtbweb.Models;
using gtbweb.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.AspNetCore.Http.Features;
using gtbweb.Services.SignalRService.Hubs;



namespace gtbweb
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
        {   services.AddEntityFrameworkProxies();
            services.AddSignalR();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlite(
                  Configuration.GetSection("ConnectionStrings")["DefaultConnection"]));

                    services.AddDbContext<ServiceDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetSection("ConnectionStrings")["DefaultConnection"]));

                    services.AddDbContext<AboutDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetSection("ConnectionStrings")["DefaultConnection"]));
                    
                     services.AddDbContext<BlogDbContext>(options =>
                     {
                      options.UseSqlite(Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
                      options.UseLazyLoadingProxies(true);
                     });
                     services.AddDbContext<ArchiveDbContext>(options =>
                     {
                        options.UseSqlite(Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
                        options.UseLazyLoadingProxies(true);
                     });
                     services.AddDbContext<VideoDbContext>(options =>
                     {
                        options.UseSqlite(Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
                        options.UseLazyLoadingProxies(true);
                     });
                   
                     
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.BuildServiceProvider()
            .GetService<Areas.Identity.Pages.Account.RegisterModel>();
            //services.BuildServiceProvider().GetService<gtbweb.Controllers.AboutController>();
            //services.BuildServiceProvider().GetService<gtbweb.Services.DatabaseService>();
            services.AddScoped<IDatabaseService, DatabaseService>();
             services.AddScoped<IEmailSender, EmailSender>();
             
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.Use(async (context, next) =>
    {
        context.Features.Get<IHttpMaxRequestBodySizeFeature>().MaxRequestBodySize = 400000000; // unlimited I guess
        await next.Invoke();
    });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
           // AboutInitializer.Seed(app);
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
             
            app.UseSignalR(route =>
            {
               route.MapHub<ServiceHub>("/ServiceHub");
            });
        }
    }
}
