using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorldCities.Data;
using WorldCities.Data.Models;
using Microsoft.AspNetCore.HttpOverrides;
using Serilog;
using template.Interface;
using template.Services;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Identity.UI.Services;
using WorldCities.Services;

namespace WorldCities
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
            services.AddControllersWithViews()
                .AddJsonOptions(options =>
                {
                    // set this option to TRUE to indent the JSON output
                    options.JsonSerializerOptions.WriteIndented = true;
                    // set this option to NULL to use PascalCase instead of CamelCase (default)
                    // options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });


            services.AddSwaggerGen();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            // Add ApplicationDbContext and SQL Server support
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")
                    )
            );

            // Add ASP.NET Core Identity support
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();



            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            // IEmailSender implementation using SendGrid
            // (disabled to avoid conflicts with MailKit-based implementation)
            // /*
            services.AddTransient<IEmailSender, SendGridEmailSender>();
            services.Configure<SendGridEmailSenderOptions>(options =>
            {
                options.ApiKey = "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";
                options.Sender_Email = "unity.development.company@gmail.com";
                options.Sender_Name = "Unity Development";
            });
            // */

            // IEmailSender implementation using MailKit
            // (disable it if you want to use the SendGrid-based implementation instead)
            // services.AddTransient<IEmailSender, MailKitEmailSender>();
            // services.Configure<MailKitEmailSenderOptions>(options =>
            // {
            //     options.Host_Address = Configuration["ExternalProviders:MailKit:SMTP:Address"];
            //     options.Host_Port = Convert.ToInt32(Configuration["ExternalProviders:MailKit:SMTP:Port"]);
            //     options.Host_Username = Configuration["ExternalProviders:MailKit:SMTP:Account"];
            //     options.Host_Password = Configuration["ExternalProviders:MailKit:SMTP:Password"];
            //     options.Sender_EMail = Configuration["ExternalProviders:MailKit:SMTP:Sender_Email"];
            //     options.Sender_Name = Configuration["ExternalProviders:MailKit:SMTP:Sender_Name"];
            // });

            services.AddScoped<LogInterface, LogServices>();
            services.AddScoped<ICommonService, CommonService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();

            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = (context) =>
                {
                    switch (context.File.Name)
                    {
                        // disable caching for these specific files
                        case "isOnline.txt":
                            context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                            context.Context.Response.Headers.Add("Expires", "-1");
                            break;
                        // use default rules (from appsettings.json) for all other files
                        default:
                            context.Context.Response.Headers["Cache-Control"] =
                                Configuration["StaticFiles:Headers:Cache-Control"];
                            break;
                    }
                }
            });

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
                app.Use(async (ctx, next) =>
                {
                    ctx.SetIdentityServerOrigin("https://bellarattan.com");
                    await next();
                });
            }

            app.UseRouting();

            // Invoke the UseForwardedHeaders middleware and configure it 
            // to forward the X-Forwarded-For and X-Forwarded-Proto headers.
            // NOTE: This must be put BEFORE calling UseAuthentication 
            // and other authentication scheme middlewares.
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor
                | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            // app.UseSwagger();
            // app.UseSwaggerUI(c => {
            //     c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V2");
            // });
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
                spa.ApplicationBuilder.UseCors(builder =>
                {
                    // Must specify Methods
                    builder.WithMethods("GET");
                    builder.WithMethods("PUT");
                    builder.WithMethods("POST");
                    builder.WithMethods("DELETE");
                    builder.WithMethods("*");

                    // Case insensitive headers
                    builder.WithHeaders("AuthoriZatioN");

                    // Can supply a list or one by one, either is fine
                    builder.WithOrigins("http://localhost:5000");
                    builder.WithOrigins("https://localhost:5001");
                    builder.WithOrigins("http://150.95.91.110");
                    builder.WithOrigins("https://150.95.91.110");
                    builder.WithOrigins("https://bellarattan.com");
                    builder.WithOrigins("*");
                    builder.WithOrigins("http://bellarattan.com");

                });

            });

            //Use the Serilog request logging middleware to log HTTP requests.
            app.UseSerilogRequestLogging();


        }
    }
}
