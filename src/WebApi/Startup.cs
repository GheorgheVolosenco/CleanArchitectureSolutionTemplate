using CarDataPlatformIngestor.Application;
using CarDataPlatformIngestor.Application.Interfaces.Services;
using CarDataPlatformIngestor.Infrastructure.Identity;
using CarDataPlatformIngestor.Infrastructure.Persistence;
using CarDataPlatformIngestor.Infrastructure.Persistence.Contexts;
using CarDataPlatformIngestor.Infrastructure.Shared;
using CarDataPlatformIngestor.WebApi.Extensions;
using CarDataPlatformIngestor.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarDataPlatformIngestor.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly IWebHostEnvironment Environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.Configuration = configuration;
            this.Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AllowAnyOrigin();
            }
            else
            {
                services.AllowSelectedOrigins(this.Configuration);
            }

            services.AddApplicationLayer();
            services.AddIdentityInfrastructure(Configuration);
            services.AddPersistenceInfrastructure(Configuration);
            services.AddSharedInfrastructure(Configuration);
            services.AddSwaggerExtension();
            services.AddControllersWithFluentValidations();
            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();
            services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.AddSecurityHeaders();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerExtension();
            app.UseErrorHandlingMiddleware();
            app.UseCors("CORSPolicy");
            app.UseHealthChecks("/health");

            app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllers();
             });
        }
    }
}
