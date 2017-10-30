// Copyright (c) Taylor Southwick. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Http;
using System;
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

        public async Task Invoke(HttpContext context, IdAccessor accessor)
        {
            var items = context.Request.Headers[SessionId];

            if (items.Count == 0 || items.Count == 1)
            {
                accessor.Id = items.Count == 0 ? Guid.NewGuid().ToString() : items[0];

                await _next(context);
            }
            else
            {
                throw new MicroserviceSessionIdException(items);
            }
        }
    }
}
