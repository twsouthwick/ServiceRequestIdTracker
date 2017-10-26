using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

using static MicroserviceSessionId.Constants;

namespace MicroserviceSessionId
{
    internal class ServiceRequestIdMiddleware
    {
        private readonly RequestDelegate _next;

        private static readonly string[] s_headers = new[] { SessionId };

        public ServiceRequestIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context, ILoggerFactory logger)
        {
            foreach (var header in s_headers)
            {
                var items = context.Request.Headers[header];

                Debug.Assert(items.Count == 0 || items.Count == 1);

                context.Items[header] = items.Count == 0 ? Guid.NewGuid().ToString() : items[0];
            }

            return _next(context);
        }
    }
}
