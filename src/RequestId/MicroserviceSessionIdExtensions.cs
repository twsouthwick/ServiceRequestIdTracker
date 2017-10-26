using MicroserviceSessionId;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace Microsoft.AspNetCore.Builder
{
    public static class MicroserviceSessionIdExtensions
    {
        public static void AddRequestId(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<HttpMessageHandler, HttpClientHandler>();
            services.AddScoped<MicroserviceRequestHttpClient>();
            services.AddScoped<IMicroserverSessionIdAccessor, IdAccessor>();
            services.Add(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(MicroserviceSessionId.Logger<>)));
        }

        public static IApplicationBuilder UseRequestId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MicroserviceSessionIdMiddleware>();
        }
    }
}

