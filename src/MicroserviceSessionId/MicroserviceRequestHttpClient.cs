﻿using System.Net.Http;

using static MicroserviceSessionId.Constants;

namespace MicroserviceSessionId
{
    public class MicroserviceRequestHttpClient : HttpClient
    {
        public MicroserviceRequestHttpClient(HttpMessageHandler handler, IMicroserverSessionIdAccessor requestId)
            : base(handler, false)
        {
            DefaultRequestHeaders.Add(SessionId, requestId.Id);
        }
    }
}