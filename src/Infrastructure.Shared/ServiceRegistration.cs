using Application.Services.Products;
using CarDataPlatformIngestor.Application.Interfaces.Services;
using CarDataPlatformIngestor.Domain.Settings;
using CarDataPlatformIngestor.Infrastructure.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarDataPlatformIngestor.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<ProductService>();
        }
    }
}
