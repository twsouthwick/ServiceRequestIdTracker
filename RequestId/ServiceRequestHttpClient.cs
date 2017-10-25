using Microsoft.AspNetCore.Http;
using System.Net.Http;

using static RequestId.Constants;

namespace RequestId
{
    public class ServiceRequestHttpClient : HttpClient
    {
        public ServiceRequestHttpClient(HttpMessageHandler handler, IServiceRequestIdAccessor requestId)
            : base(handler, false)
        {
            DefaultRequestHeaders.Add(SessionId, requestId.Id);
        }
    }
}
