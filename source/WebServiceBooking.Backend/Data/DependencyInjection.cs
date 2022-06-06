using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using WebServiceBooking.Backend.Common;
using WebServiceBooking.Backend.Data.Entities;
using WebServiceBooking.Backend.IdentityServer;
using WebServiceBooking.Backend.Services;
namespace WebServiceBooking.Backend.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<WebDBContext>(options =>
                    options.UseInMemoryDatabase("ServiceBookingDB"));
            }
            else
            {
                services.AddDbContext<WebDBContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(WebDBContext).Assembly.FullName)));
            }



            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
            });

            return services;
        }

        public static IServiceCollection SetupIdentityServer(this IServiceCollection services)
        {

            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>)); services
    .AddDefaultIdentity<User>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<WebDBContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<User, WebDBContext>();

            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
            });

            return services;
        }
            //public static IServiceCollection SetupIdentityServer(this IServiceCollection services)
            //{
            //    //2. Setup idetntity
            //    services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<WebDBContext>();

            //    var builder = services.AddIdentityServer(options =>
            //    {
            //        options.Events.RaiseErrorEvents = true;
            //        options.Events.RaiseInformationEvents = true;
            //        options.Events.RaiseFailureEvents = true;
            //        options.Events.RaiseSuccessEvents = true;
            //    })
            //    .AddInMemoryApiResources(Config.Apis)
            //    .AddInMemoryClients(Config.Clients)
            //    .AddInMemoryIdentityResources(Config.Ids)
            //    .AddAspNetIdentity<User>()
            //    .AddDeveloperSigningCredential();



            //    services.Configure<IdentityOptions>(options =>
            //    {
            //        // Default Lockout settings.
            //        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //        options.Lockout.MaxFailedAccessAttempts = 5;
            //        options.Lockout.AllowedForNewUsers = true;
            //        options.SignIn.RequireConfirmedPhoneNumber = false;
            //        options.SignIn.RequireConfirmedAccount = false;
            //        options.SignIn.RequireConfirmedEmail = false;
            //        options.Password.RequiredLength = 8;
            //        options.Password.RequireDigit = true;
            //        options.Password.RequireUppercase = true;
            //        options.User.RequireUniqueEmail = true;
            //    });



            //    services.AddAuthentication()
            //       .AddLocalApi("Bearer", option =>
            //       {
            //           option.ExpectedScope = "api.Service";
            //       });

            //    services.AddAuthorization(options =>
            //    {
            //        options.AddPolicy("Bearer", policy =>
            //        {
            //            policy.AddAuthenticationSchemes("Bearer");
            //            policy.RequireAuthenticatedUser();
            //        });
            //    });

            //    services.AddRazorPages(options =>
            //    {
            //        options.Conventions.AddAreaFolderRouteModelConvention("Identity", "/Account/", model =>
            //        {
            //            foreach (var selector in model.Selectors)
            //            {
            //                var attributeRouteModel = selector.AttributeRouteModel;
            //                attributeRouteModel.Order = -1;
            //                attributeRouteModel.Template = attributeRouteModel.Template.Remove(0, "Identity".Length);
            //            }
            //        });
            //    });
            //    return services;
            //}
        }
}