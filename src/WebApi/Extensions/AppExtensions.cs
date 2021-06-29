using CarDataPlatformIngestor.WebApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using WebApi.Middlewares;

namespace CarDataPlatformIngestor.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseMiddleware<SwaggerHeadersMiddleware>();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Architecture API");
            });
        }

        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }

        public static void AddSecurityHeaders(this IApplicationBuilder app)
        {
            app.UseHsts(); // [HSTS] HTTP Strict Transport Security Header
            app.UseXContentTypeOptions(); // X-Content-Type-Options Header
            app.UseNoCacheHttpHeaders(); // No cache
            app.UseXXssProtection(options => options.EnabledWithBlockMode()); // X-XSS-Protection Header
            app.UseReferrerPolicy(options => options.NoReferrer()); //Referrer-Policy Http Reader
            app.UseXfo(options => options.SameOrigin()); // X-Frame-Options Header
            app.UseCsp(options => options.DefaultSources(s => s.Self())
                .StyleSources(s => s.Self()) // [CSP] Content-Security-Policy Header
                .FontSources(s => s.Self())
                .FormActions(s => s.Self())
                .FrameSources(s => s.Self())
                .MediaSources(s => s.Self())
                .ObjectSources(s => s.Self())
                .FrameAncestors(s => s.None())
                .ImageSources(s => s.Self())
                .ScriptSources(s => s.Self()));
        }
    }
}
