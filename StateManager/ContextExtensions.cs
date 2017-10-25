using static StateManager.Constants;

namespace Microsoft.AspNetCore.Http
{
    public static class ContextExtensions
    {
        public static string GetId(this HttpContext context) => (string)context.Items[SessionId];
    }
}
