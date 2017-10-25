using Microsoft.AspNetCore.Http;

namespace RequestId
{
    internal class ServiceRequestIdAccessor : IServiceRequestIdAccessor
    {
        public ServiceRequestIdAccessor(IHttpContextAccessor contextAccessor)
        {
            Id = contextAccessor.HttpContext.GetId();
        }

        public string Id { get; }
    }
}
