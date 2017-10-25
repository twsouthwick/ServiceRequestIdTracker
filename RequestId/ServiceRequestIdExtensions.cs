using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RequestId;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
        }

        public static IApplicationBuilder UseRequestId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ServiceRequestIdMiddleware>();
        }
    }
}

