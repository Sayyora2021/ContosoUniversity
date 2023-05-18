using ContosoUniversity.Middlewares;

namespace ContosoUniversity.Extensions
{
    public static class ApplicationMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomHeaders(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomHeadersMiddleware>();
        }
    }
}

