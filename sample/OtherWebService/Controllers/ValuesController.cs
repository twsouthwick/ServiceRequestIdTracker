using MicroserviceSessionId;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OtherWebService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IMicroserviceSessionIdAccessor _requestId;

        public ValuesController(ILogger<ValuesController> logger, IMicroserviceSessionIdAccessor requestId)
        {
            _logger = logger;
            _requestId = requestId;
        }

        public string Get()
        {
            using (_logger.BeginScope("hello"))
            {
                _logger.LogInformation("Running OtherWebService.Values.Get");
            }

            return _requestId.Id;
        }
    }
}
