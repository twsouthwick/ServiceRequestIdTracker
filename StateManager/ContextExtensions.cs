using System;

using static StateManager.Constants;

namespace Microsoft.AspNetCore.Http
{
    public static class ContextExtensions
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
