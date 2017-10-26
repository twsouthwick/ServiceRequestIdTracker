using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

using static MicroserviceSessionId.Constants;

namespace MicroserviceSessionId
{
    internal class MicroserviceSessionIdMiddleware
    {
        private readonly RequestDelegate _next;

        public MicroserviceSessionIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context, IdAccessor accessor)
        {
            var items = context.Request.Headers[SessionId];

            Debug.Assert(items.Count == 0 || items.Count == 1);

            accessor.Id = items.Count == 0 ? Guid.NewGuid().ToString() : items[0];

            return _next(context);
        }
    }
}
