using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RequestId;

namespace OtherWebService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IServiceRequestIdAccessor _requestId;

        public ValuesController(ILogger<ValuesController> logger, IServiceRequestIdAccessor requestId)
        {
            _logger = logger;
            _requestId = requestId;
        }

        public string Get()
        {
            _logger.LogInformation("Running OtherWebService.Values.Get");
            return _requestId.Id;
        }
    }
}
