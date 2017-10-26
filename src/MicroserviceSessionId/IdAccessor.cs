using Microsoft.AspNetCore.Http;

using static MicroserviceSessionId.Constants;

namespace MicroserviceSessionId
{
    internal class IdAccessor : IMicroserviceSessionIdAccessor
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public IdAccessor(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string Id => _contextAccessor.HttpContext?.Items[SessionId] as string;
    }
}
