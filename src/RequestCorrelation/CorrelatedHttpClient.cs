// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Net.Http;

using static RequestCorrelation.Constants;

namespace RequestCorrelation
{
    public class CorrelatedHttpClient : HttpClient
    {
        public CorrelatedHttpClient(HttpMessageHandler handler, ICorrelationIdAccessor requestId)
            : base(handler, false)
        {
            DefaultRequestHeaders.Add(CorrelationIdHeader, requestId.Id);
        }
    }
}
