using StateManager;

namespace Microsoft.AspNetCore.Builder
{
    public static class SessionStateMiddlewareExtensions
    {
        public static IApplicationBuilder UseSessionStateTracking(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SessionStateMiddleware>();
        }
    }
}

