// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

using static RequestCorrelation.Constants;

namespace RequestCorrelation
{
    internal class RequestCorrelationMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCorrelationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<RequestCorrelationMiddleware> log, CorrelationIdAccessor accessor)
        {
            var items = context.Request.Headers[CorrelationIdHeader];

            if (items.Count == 0 || items.Count == 1)
            {
                var id = items.Count == 0 ? Guid.NewGuid().ToString() : items[0];

                accessor.Id = id;

                using (log.BeginScope("CorrelationId: {CorrelationId}", id))
                {
                    await _next(context);
                }
            }
            else
            {
                throw new RequestCorrelationException(items);
            }
        }
    }
}
