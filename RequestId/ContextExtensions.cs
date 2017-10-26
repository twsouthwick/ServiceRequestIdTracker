using Microsoft.AspNetCore.Http;

using static RequestId.Constants;

namespace RequestId
{
    internal static class ContextExtensions
    {
        public static string GetId(this HttpContext context) => context.Items[SessionId] as string;
    }
}
