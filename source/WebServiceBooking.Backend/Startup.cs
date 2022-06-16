using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceBooking.Backend.Data;
using WebServiceBooking.Backend.Data.Entities;
using WebServiceBooking.SendMail;

namespace WebServiceBooking.Backend
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
            services.AddRazorPages();
            {
                services.AddOptions();                                        // Kích hoạt Options
                var mailsettings = Configuration.GetSection("MailSettings");  // đọc config
                services.Configure<MailSettings>(mailsettings);               // đăng ký để Inject

                services.AddTransient<IEmailSender, SendMailService>();        // Đăng ký dịch vụ Mail


                // Register DbContext
                services.AddDbContext<WebDBContext>(options =>
                {
                    // cnn
                    string connectstring = Configuration.GetConnectionString("ServiceBookingConnection");
                    options.UseSqlServer(connectstring);
                });
                //Register Identity
                //services.AddIdentity<User, IdentityRole>()
                //    .AddEntityFrameworkStores<WebDBContext>()
                //    .AddDefaultTokenProviders();

                services.AddDefaultIdentity<User>() // use default  Identity UI 
                        .AddEntityFrameworkStores<WebDBContext>()
                        .AddDefaultTokenProviders();

                //  IdentityOptions
                services.Configure<IdentityOptions>(options =>
                {
                    // config Password
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequiredUniqueChars = 1;

                    // config Lockout - khóa user
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;

                    // config for User.
                    options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = true;

                    // config login.
                    options.SignIn.RequireConfirmedEmail = true;
                    options.SignIn.RequireConfirmedPhoneNumber = false;

                });
            }
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

            app.UseAuthentication(); // Restore info user signed
            app.UseAuthorization(); // Restore info user role

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
