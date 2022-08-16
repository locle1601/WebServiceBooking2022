﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceBooking.Backend.Data;
using WebServiceBooking.Backend.Data.Entities;
using WebServiceBooking.Backend.Extensions;
using WebServiceBooking.Backend.Helpers;
using WebServiceBooking.SendMail;

namespace WebServiceBooking.Backend
{
    public class Startup
    {
        private readonly string SpecificOrigins = "SpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddOptions();                                        // Kích hoạt Options
            var mailsettings = Configuration.GetSection("MailSettings");  // đọc config
            services.Configure<MailSettings>(mailsettings);               // đăng ký để Inject
            services.AddTransient<IEmailSender, SendMailService>();       // Đăng ký dịch vụ Mail

            //1. Setup entity framework
            if (Configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<WebDBContext>(options =>
                    options.UseInMemoryDatabase("ServiceBookingDB"));
            }
            else
            {
                services.AddDbContextPool<WebDBContext>(options =>
                {
                    // cnn
                    string connectstring = Configuration.GetConnectionString("ServiceBookingConnection");
                    options.UseSqlServer(connectstring);
                });
            }

            //2. Setup idetntity
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            })
                    .AddEntityFrameworkStores<WebDBContext>();
            //.AddDefaultTokenProviders();
            services.AddTransient<DbInitializer>();

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
                .AddInMemoryApiResources(IdentityServerConfig.Apis)
                .AddInMemoryApiScopes(IdentityServerConfig.GetApiScopes)
                //.AddInMemoryClients(IdentityServerConfig.Clients)
                .AddInMemoryClients(Configuration.GetSection("IdentityServer:Clients")) // đọc config từ appsettings  
                .AddInMemoryIdentityResources(IdentityServerConfig.Ids)
                .AddAspNetIdentity<User>()
                .AddDeveloperSigningCredential();

            services.AddCors(options =>
            {
                options.AddPolicy(SpecificOrigins,
                builder =>
                {
                    builder.WithOrigins(Configuration["AllowOrigins"])
                        .AllowAnyHeader()
                        // .AllowAnyOrigin()
                        .AllowAnyMethod();

                });
            });

            services.Configure<IdentityOptions>(options =>
            {
                //config Password
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;

                //config Lockout -khóa user
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

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            //services.AddControllersWithViews()
            //    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RoleCreateRequestValidator>());

            // Config Swagger
            services.AddAuthentication()
                   .AddLocalApi("Bearer", option =>
                   {
                       option.ExpectedScope = IdentityServerConfig.ApiName;
                   });


            services.AddAuthorization(options =>
            {
                options.AddPolicy("Bearer", policy =>
                {
                    policy.AddAuthenticationSchemes("Bearer");
                    policy.RequireAuthenticatedUser();
                });

            });

            services.AddRazorPages(options =>
            {
                options.Conventions.AddAreaFolderRouteModelConvention("Identity", "/Account/", model =>
                {
                    foreach (var selector in model.Selectors)
                    {
                        var attributeRouteModel = selector.AttributeRouteModel;
                        attributeRouteModel.Order = -1;
                        attributeRouteModel.Template = attributeRouteModel.Template.Remove(0, "Identity".Length);
                    }
                });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = IdentityServerConfig.ApiFriendlyName, Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("http://localhost:5001/connect/authorize"),
                            Scopes = new Dictionary<string, string> { { IdentityServerConfig.ApiName, IdentityServerConfig.ApiFriendlyName } }
                        },
                    },
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new List<string>{IdentityServerConfig.ApiName }
                    }
                });
            });


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
            app.UseErrorWrapping();
            app.UseStaticFiles();

            app.UseIdentityServer();
            app.UseAuthentication(); // Restore info user signed
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();// Restore info user role
            app.UseCors(SpecificOrigins);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "Swagger UI - QuickApp";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{IdentityServerConfig.ApiFriendlyName} V1");
                c.OAuthClientId(IdentityServerConfig.SwaggerClientID);
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}