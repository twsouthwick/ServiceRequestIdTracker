using Microsoft.Extensions.DependencyInjection;
using StateManager;
using System.Net.Http;

namespace Microsoft.AspNetCore.Builder
{
    public static class SessionStateMiddlewareExtensions
    {
        public static void AddRequestId(this IServiceCollection services)
        {
            services.AddSingleton<HttpMessageHandler, HttpClientHandler>();
            services.AddScoped<RequestHttpClient>();
            services.AddScoped<IRequestIdAccessor, RequestIdAccessor>();
        }

        public static IApplicationBuilder UseRequestId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SessionStateMiddleware>();
        }
    }
}

