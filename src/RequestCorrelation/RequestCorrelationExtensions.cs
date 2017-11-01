// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RequestCorrelation;
using System.Net.Http;

namespace Microsoft.AspNetCore.Builder
{
    public static class RequestCorrelationExtensions
    {
        public static void AddRequestCorrelation(this IServiceCollection services)
        {
            services.TryAddSingleton<HttpMessageHandler, HttpClientHandler>();
            services.AddScoped<CorrelatedHttpClient>();
            services.AddScoped<ICorrelationIdAccessor, CorrelationIdAccessor>();
        }

        public static IApplicationBuilder UseRequestCorrelation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestCorrelationMiddleware>();
        }
    }
}
