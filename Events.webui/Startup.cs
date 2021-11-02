using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Events.webui.Context;
using Events.webui.EmailServices;
using Events.webui.Identity;
using Events.webui.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Events.webui
{
    public class Startup
    {
        private IConfiguration _Configuration;
        public Startup(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }
       
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationContext>(options=> options.UseSqlite("Data Source=TicketDatabase"));
            services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options=> {
                // password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;

                // Lockout                
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                // options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options=> {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".Events.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });
             services.AddScoped<IEmailSender,SmtpEmailSender>(i=> 
                new SmtpEmailSender(
                    _Configuration["EmailSender:Host"],
                    _Configuration.GetValue<int>("EmailSender:Port"),
                    _Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    _Configuration["EmailSender:UserName"],
                    _Configuration["EmailSender:Password"])
                );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles(); // wwwroot

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),
                    RequestPath="/modules"                
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                        name:"AdminVenueEdit",
                        pattern:"Admin/venue/edit/{id?}",
                        defaults:new {controller="Admin", Action="VenueEdit"}
                );
                endpoints.MapControllerRoute(
                        name:"AdminArtistEdit",
                        pattern:"Admin/artist/edit/{id?}",
                        defaults:new {controller="Admin", Action="ArtistEdit"}
                );
                endpoints.MapControllerRoute(
                        name:"AdminVenueCreate",
                        pattern:"Admin/venue/create",
                        defaults:new {controller="Admin", Action="VenueCreate"}
                );   
                endpoints.MapControllerRoute(
                        name:"AdminVenueList",
                        pattern:"Admin/Venue",
                        defaults:new {controller="Admin", Action="VenueList"}
                );    
                endpoints.MapControllerRoute(
                        name:"AdminArtistList",
                        pattern:"Admin/artist",
                        defaults:new {controller="Admin", Action="ArtistList"}
                );
                endpoints.MapControllerRoute(
                        name:"AdminEventEdit",
                        pattern:"Admin/event/edit/{id?}",
                        defaults:new {controller="Admin", Action="EventEdit"}
                );
                endpoints.MapControllerRoute(
                        name:"AdminEventCreate",
                        pattern:"Admin/event/create",
                        defaults:new {controller="Admin", Action="EventCreate"}
                );
                endpoints.MapControllerRoute(
                        name:"AdminEventList",
                        pattern:"Admin/event",
                        defaults:new {controller="Admin", Action="EventList"}
                );
                endpoints.MapControllerRoute(
                        name:"AdminPanel",
                        pattern:"Admin",
                        defaults:new {controller="Admin", Action="Admin"}
                );
                endpoints.MapControllerRoute(
                        name:"SearchVenue",
                        pattern:"SearchVenue",
                        defaults:new {controller="Home", Action="SearchVenue"}
                );
                endpoints.MapControllerRoute(
                        name:"Register",
                        pattern:"Register",
                        defaults:new {controller="Account", Action="Register"}
                );
                endpoints.MapControllerRoute(
                        name:"Account",
                        pattern:"login",
                        defaults:new {controller="Account", Action="Login"}
                );
                 endpoints.MapControllerRoute(
                        name:"searchartist",
                        pattern:"searchartist",
                        defaults:new {controller="Home", Action="searchartist"}
                );
                endpoints.MapControllerRoute(
                        name:"Artistler",
                        pattern:"Artist",
                        defaults:new {controller="Home", Action="Artist"}
                );
                endpoints.MapControllerRoute(
                        name:"Venue",
                        pattern:"Venue",
                        defaults:new {controller="Home", Action="Venue"}
                );
                endpoints.MapControllerRoute(
                        name:"Events",
                        pattern:"Events",
                        defaults:new {controller="Home", Action="Events"}
                );
                endpoints.MapControllerRoute(
                        name:"SearchOne",
                        pattern:"Search",
                        defaults:new {controller="Home", Action="Search"}
                );
                endpoints.MapControllerRoute(
                        name:"EventDetails",
                        pattern:"home/{url}",
                        defaults:new {controller="Home", Action="EventDetail"}
                );
                 endpoints.MapControllerRoute(
                        name:"home",
                        pattern:"{name}",
                        defaults:new {controller="Home", Action="Index"}
                );
                endpoints.MapControllerRoute(
                        name:"default",
                        pattern:"{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
