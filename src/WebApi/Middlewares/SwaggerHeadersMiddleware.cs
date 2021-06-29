using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApi.Middlewares
{
    /// <summary>
    /// To access swagger page, Content Security Policy(CSP) Header should be removed for the Web URL Path containing: "swagger".
    /// </summary>
    public class SwaggerHeadersMiddleware
    {
        private readonly RequestDelegate next;

        public SwaggerHeadersMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path.Value;
            if (context.Request.Path.Value.Contains("swagger"))
            {
                context.Response.Headers.Remove("content-security-policy");
            }

            await this.next.Invoke(context);
        }
    }
}
