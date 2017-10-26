using System.Net.Http;

using static MicroserviceSessionId.Constants;

namespace MicroserviceSessionId
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
