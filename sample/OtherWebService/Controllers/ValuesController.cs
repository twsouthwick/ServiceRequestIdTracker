using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MicroserviceSessionId;

namespace OtherWebService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IMicroserverSessionIdAccessor _requestId;

        public ValuesController(ILogger<ValuesController> logger, IMicroserverSessionIdAccessor requestId)
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
