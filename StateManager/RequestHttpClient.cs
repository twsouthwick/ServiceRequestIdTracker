
using Microsoft.AspNetCore.Http;

using static StateManager.Constants;

namespace System.Net.Http
{
    public class RequestHttpClient : HttpClient
    {
        public RequestHttpClient(HttpMessageHandler handler, IHttpContextAccessor contextAccessor)
            : base(handler, false)
        {
            DefaultRequestHeaders.Add(SessionId, contextAccessor.HttpContext.GetId());
        }
    }
}
