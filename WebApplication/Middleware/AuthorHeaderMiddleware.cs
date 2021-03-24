using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplication.Middleware
{
    public class AuthorHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            httpContext.Request.Headers.Add("Author", "ZhabinDA");
            await _next(httpContext);
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthorHeaderMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorHeaderMiddleware>();
        }
    }
}
