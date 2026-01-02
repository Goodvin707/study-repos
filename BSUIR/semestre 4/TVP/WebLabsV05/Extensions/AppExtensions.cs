using Microsoft.AspNetCore.Builder;
using WebLabsV05.Middleware;

namespace WebLabsV05.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogMiddleware>();
        }
    }
}
