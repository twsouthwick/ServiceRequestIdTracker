using MicroserviceSessionId;
using Microsoft.Extensions.DependencyInjection;
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

            // Register an id accessor for external and internal use
            var accessor = new IdAccessor();
            services.Add(ServiceDescriptor.Singleton(accessor));
            services.Add(ServiceDescriptor.Singleton<IMicroserviceSessionIdAccessor>(accessor));

            // Override internal ILogger<> instance with a custom one to track the microservice session id when available
            services.Add(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(MicroserviceSessionId.Logger<>)));
        }

        public static IApplicationBuilder UseMicroserviceSessionId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MicroserviceSessionIdMiddleware>();
        }
    }
}

