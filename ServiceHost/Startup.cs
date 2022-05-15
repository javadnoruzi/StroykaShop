using AccountMangment.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopMangmnet.Infrastructure.Bootstrapper;
using StroykaShop.Framework;
using StroykaShop.Framework.Application;
using System.Collections.Generic;

namespace ServiceHost
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
            services.AddHttpContextAccessor();

            var ConnectinString = Configuration.GetConnectionString("EfCore");
            ShopMangmentBootstapperr.Configure(services, ConnectinString);
            AccountMangmentBootstrapperr.Configur(services,ConnectinString);
            services.AddSingleton<IFileUpload, FileUpload>();
            services.AddTransient<IAuthHelper, AuthHelper>();
            


            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Account");
                    o.LogoutPath = new PathString("/Account");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminArea",
                    builder => builder.RequireRole(new List<string> { "1", "3" }));

                options.AddPolicy("Shop",
                    builder => builder.RequireRole(new List<string> {"1" }));

                options.AddPolicy("Discount",
                    builder => builder.RequireRole(new List<string> { "1" }));

                options.AddPolicy("Account",
                    builder => builder.RequireRole(new List<string> { "1" }));
            });

            services.AddRazorPages()
                .AddMvcOptions(option=>option.Filters.Add<SecurityPageFilter>())
                .AddRazorPagesOptions(options=>options.Conventions
            .AuthorizeAreaFolder("Adminstretion","/","AdminArea"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
