using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RequestId;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Builder
{
    public static class ServiceRequestIdExtensions
    {
        public static void AddRequestId(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<HttpMessageHandler, HttpClientHandler>();
            services.AddScoped<ServiceRequestHttpClient>();
            services.AddScoped<IServiceRequestIdAccessor, ServiceRequestIdAccessor>();
            services.Add(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(RequestIdLogger<>)));
        }

        public static IApplicationBuilder UseRequestId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ServiceRequestIdMiddleware>();
        }
    }
}

