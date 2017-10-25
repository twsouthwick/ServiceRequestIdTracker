using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using StateManager;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class SessionStateMiddlewareExtensions
    {
        public static IApplicationBuilder UseSessionStateTracking(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SessionStateMiddleware>();
        }
    }

}

namespace System
{
    public static class HttpClientSessionStateExtensions
    {
        public static Task SendAsync(this HttpClient client, HttpContext context, HttpRequestMessage request, CancellationToken token)
        {
            request.Headers.Add(Constants.SessionId, (string)context.Items[Constants.SessionId]);
            return client.SendAsync(request, token);
        }
    }

}
