using Microsoft.AspNetCore.Http;

namespace MicroserviceSessionId
{
    internal class IdAccessor : IMicroserverSessionIdAccessor
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public IdAccessor(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string Id => _contextAccessor.HttpContext.GetId();
    }
}
