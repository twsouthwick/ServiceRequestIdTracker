using Microsoft.AspNetCore.Http;

using static MicroserviceSessionId.Constants;

namespace MicroserviceSessionId
{
    internal static class ContextExtensions
    {
        public static string GetId(this HttpContext context) => context.Items[SessionId] as string;
    }
}
