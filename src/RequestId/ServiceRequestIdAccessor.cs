using Microsoft.AspNetCore.Http;

namespace RequestId
{
    internal class ServiceRequestIdAccessor : IServiceRequestIdAccessor
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ServiceRequestIdAccessor(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string Id => _contextAccessor.HttpContext.GetId();
    }
}
