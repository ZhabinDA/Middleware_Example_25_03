using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace WebApplication.Middleware
{
    public class TimeHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public TimeHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var startTime = DateTime.Now;
            httpContext.Request.Headers.Add("StartTime", startTime.ToString("hh:mm:ss"));

            await _next(httpContext);

            // Не будет возвращено из сервиса, т.к. он уже отработал.
            var endTime = DateTime.Now;
            httpContext.Request.Headers.Add("EndTime", endTime.ToString("hh:mm:ss"));
        }
    }

    public static class TimeHeaderExtensions
    {
        public static IApplicationBuilder UseTimeHeaderMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeHeaderMiddleware>();
        }
    }
}
