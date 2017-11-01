// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using RequestCorrelation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace RequestIdExample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly CorrelatedHttpClient _client;
        private readonly ICorrelationIdAccessor _requestId;

        public ValuesController(ILogger<ValuesController> logger, CorrelatedHttpClient client, ICorrelationIdAccessor requestId)
        {
            _logger = logger;
            _client = client;
            _requestId = requestId;
        }

        public async Task<string> Get()
        {
            _logger.LogInformation("Running Values.Get");

            var result = await _client.GetStringAsync("http://localhost:5367/api/values");

            return $"{result}{Environment.NewLine}{_requestId.Id}";
        }
    }
}
