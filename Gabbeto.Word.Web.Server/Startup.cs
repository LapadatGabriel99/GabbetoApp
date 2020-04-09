using Gabbetto.Word.Web.Server;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Gabbetto.Word.Web.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            IocContainer.Configuration = configuration;
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            // Add ApplicationDbContext to DI
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(IocContainer.Configuration.GetConnectionString("DefaultConnection")));

            // AddIdentity adds cookie based authentication
            // Adds scoped classes for things like UserManager, SignInManager, PasswordHashers etc..
            // NOTE: Automatically adds the validated user from a cookie to the HttpContext.User
            // https://github.com/aspnet/Identity/blob/master/src/Identity/IdentityServiceCollectionExtensions.cs
            services.AddIdentity<ApplicationUser, IdentityRole>()

                    // Adds UserStore and RoleStore for this context
                    // That are consumed by UserManager and RoleManager
                    // https://github.com/aspnet/Identity/blob/master/src/EF/IdentityEntityFrameworkBuilderExtensions.cs
                    .AddEntityFrameworkStores<ApplicationDbContext>()

                    // Adds a provider that generates unique keys and hashes for things like
                    // forgot password links, phone number verification codes
                    .AddDefaultTokenProviders();

            // Add JWT Authentification for api clients
            services.AddAuthentication().
                AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = IocContainer.Configuration.GetSection("Jwt")["Issuer"],
                        ValidAudience = IocContainer.Configuration.GetSection("Jwt")["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IocContainer.Configuration.GetSection("Jwt")["SecretKey"]))
                    };
                });

            // Alter app cookie info
            services.ConfigureApplicationCookie(options =>
            {
                //Redirect to /login
                options.LoginPath = "/login";

                //Change cookie timeout to expire in 15 seconds
                options.ExpireTimeSpan = TimeSpan.FromSeconds(15);
            });            

            // Change password policy
            services.Configure<IdentityOptions>(options =>
            {
                // Make really weak possible passwords for now
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                // Make sure users have unique emails
                options.User.RequireUniqueEmail = true;
            });

            // Inject Mvc service into the service colletion
            // Also add xml formatters for input and output(for the response/request actions)
            services.AddMvc(options =>
            {
                options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Store this applications provider
            IocContainer.Provider = (ServiceProvider)app.ApplicationServices;

            // Setup Identity
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
