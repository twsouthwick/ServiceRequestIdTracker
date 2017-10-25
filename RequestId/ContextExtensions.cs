using Microsoft.AspNetCore.Http;
using System;

using static RequestId.Constants;

namespace RequestId
{
    internal static class ContextExtensions
    {
        public static string GetId(this HttpContext context)
        {
            if (context.Items[SessionId] is string id)
            {
                return id;
            }

            throw new InvalidOperationException("Id is only available if UseSessionStateTracking is enabled");
        }
    }
}
