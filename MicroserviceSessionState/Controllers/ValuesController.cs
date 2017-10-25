using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using StateManager;

namespace MicroserviceSessionState.Controllers
{
    [Route("api/[controller]")]
    public class OtherController
    {
        private readonly IRequestIdAccessor _requestId;

        public OtherController(IRequestIdAccessor requestId)
        {
            _requestId = requestId;
        }

        public string Get()
        {
            return _requestId.Id;
        }
    }

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly RequestHttpClient _client;
        private readonly IRequestIdAccessor _requestId;

        public ValuesController(RequestHttpClient client, IRequestIdAccessor requestId)
        {
            _client = client;
            _requestId = requestId;
        }

        public async Task<string> Get()
        {
            var result = await _client.GetStringAsync("http://localhost:14392/api/other");

            return $"{result}{Environment.NewLine}{_requestId.Id}";
        }
    }
}