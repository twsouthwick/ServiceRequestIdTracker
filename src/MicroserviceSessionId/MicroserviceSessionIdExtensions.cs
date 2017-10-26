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
        public static void AddMicroserviceSessionId(this IServiceCollection services)
        {
            services.AddSingleton<HttpMessageHandler, HttpClientHandler>();
            services.AddScoped<MicroserviceRequestHttpClient>();
            services.AddSingleton<IMicroserviceSessionIdAccessor, IdAccessor>();

            // IHttpContextAccessor is not available, register it for future use
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Override internal ILogger<> instance with a custom one to track the microservice session id when available
            services.Add(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(MicroserviceSessionId.Logger<>)));
        }

        public static IApplicationBuilder UseMicroserviceSessionId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MicroserviceSessionIdMiddleware>();
        }
    }
}

