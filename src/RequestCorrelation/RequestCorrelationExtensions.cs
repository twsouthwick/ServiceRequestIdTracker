// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using RequestCorrelation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;

namespace Microsoft.AspNetCore.Builder
{
    public static class RequestCorrelationExtensions
    {
        public static void AddRequestCorrelation(this IServiceCollection services)
        {
            services.TryAddSingleton<HttpMessageHandler, HttpClientHandler>();
            services.AddScoped<CorrelatedHttpClient>();

            // Register an id accessor for external and internal use
            var accessor = new CorrelationIdAccessor();
            services.Add(ServiceDescriptor.Singleton(accessor));
            services.Add(ServiceDescriptor.Singleton<ICorrelationIdAccessor>(accessor));
        }

        public static IApplicationBuilder UseRequestCorrelation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestCorrelationMiddleware>();
        }
    }
}
