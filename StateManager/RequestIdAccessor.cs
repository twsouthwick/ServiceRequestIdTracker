using Microsoft.AspNetCore.Http;

namespace StateManager
{
    internal class RequestIdAccessor : IRequestIdAccessor
    {
        public RequestIdAccessor(IHttpContextAccessor contextAccessor)
        {
            Id = contextAccessor.HttpContext.GetId();
        }

        public string Id { get; }
    }
}
