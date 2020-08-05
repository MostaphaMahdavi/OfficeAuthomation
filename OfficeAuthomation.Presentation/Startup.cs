using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OfficeAuthomation.DataAccessCommands.Context;
using OfficeAuthomation.Domains.Accounts.Roles.Entities;
using OfficeAuthomation.Domains.Accounts.Users.Entities;
using OfficeAuthomation.Presentation.Utilities.Extentions.IOCs;
using OfficeAuthomation.Presentation.Utilities.Extentions.Validations;
using Serilog;

namespace OfficeAuthomation.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            #region SeriLog

            Log.Logger = new LoggerConfiguration()

                .ReadFrom.Configuration(Configuration)
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
            #endregion


        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();


            #region Context

            services.AddDbContext<OfficeAuthomationContext>(option =>
                 { option.UseSqlServer(Configuration["ConnectionStrings:CommandConnection"]); });
           
            #endregion

            #region Identity

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<OfficeAuthomationContext>()
                .AddDefaultTokenProviders();


            #endregion

            #region Mapper

            services.AddAutoMapper(typeof(Startup));

            #endregion

            #region MediatR

            var assembly = AppDomain.CurrentDomain.Load("OfficeAuthomation.Servicess");
            services.AddMediatR(assembly);


            #endregion
            #region IOC

            services.AddIoc();

            #endregion
            
            #region Validation

            services.AddValidation();

            #endregion

            services.AddAuthentication();
            services.AddMvc().AddRazorRuntimeCompilation();
            services.AddKendo();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseRouting();

            #region SeriLog

            loggerFactory.AddSerilog();

            #endregion

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "AdminPanel",
                    areaName: "AdminPanel",
                    pattern: "AdminPanel/{controller=Dashboard}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "UserPanel",
                    areaName: "UserPanel",
                    pattern: "UserPanel/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
