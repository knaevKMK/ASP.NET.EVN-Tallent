namespace EVNTalent.Web
{
    using System;
    using EVNTalent.Services.Common.Infrastructure;
    using MediatR;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.SpaServices.AngularCli;
    using EVNTalent.Services.Common.Interfaces;
    using EVNTalent.Services.Common.Extensions;
    using EVNTalent.Services.Common.ValidationHandler;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>(config =>
            {
                config.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();

            services.AddFluentValidation(config => {
                config.RegisterValidatorsFromAssemblyContaining<ValidationCandidateCreate>();
                config.RegisterValidatorsFromAssemblyContaining<ValidationDeparmetntAdd>();
                config.AutomaticValidationEnabled = true;
                config.DisableDataAnnotationsValidation = true;
                config.ImplicitlyValidateChildProperties = true;
                config.ImplicitlyValidateRootCollectionElements = true;
            });
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddTransient<IApplicaitonDbContext, ApplicationDbContext>();
            services.AddScoped<IMediator, Mediator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMediator mediatR)
        {
            app.PrepareDatabse(mediatR);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            //Todo 
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
