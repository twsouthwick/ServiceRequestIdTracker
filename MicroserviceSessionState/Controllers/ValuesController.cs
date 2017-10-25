using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace MicroserviceSessionState.Controllers
{
    [Route("api/[controller]")]
    public class OtherController : Controller
    {
        public string Get()
        {
            return HttpContext.GetId();
        }
    }

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly RequestHttpClient _client;

        public ValuesController(RequestHttpClient client)
        {
            _client = client;
        }

        public async Task<string> Get()
        {
            var result = await _client.GetStringAsync("http://localhost:14392/api/other");

            return $"{result}{Environment.NewLine}{HttpContext.GetId()}";
        }
    }
}