// Copyright (c) Taylor Southwick. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using RequestCorrelation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OtherWebService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly ICorrelationIdAccessor _requestId;

        public ValuesController(ILogger<ValuesController> logger, ICorrelationIdAccessor requestId)
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
