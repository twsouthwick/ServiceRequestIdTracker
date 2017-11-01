// Copyright (c) Taylor Southwick. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using MicroserviceSessionId;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;

namespace Microsoft.AspNetCore.Builder
{
    public static class MicroserviceSessionIdExtensions
    {
        public static void AddMicroserviceSessionId(this IServiceCollection services)
        {
            services.TryAddSingleton<HttpMessageHandler, HttpClientHandler>();
            services.AddScoped<MicroserviceRequestHttpClient>();

            // Register an id accessor for external and internal use
            var accessor = new IdAccessor();
            services.Add(ServiceDescriptor.Singleton(accessor));
            services.Add(ServiceDescriptor.Singleton<IMicroserviceSessionIdAccessor>(accessor));
        }

        public static IApplicationBuilder UseMicroserviceSessionId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MicroserviceSessionIdMiddleware>();
        }
    }
}
