using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading;

namespace MicroserviceSessionState.Controllers
{
    [Route("api/[controller]")]
    public class OtherController
    {
        public int Get()
        {
            return 5;
        }
    }

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly HttpClient _client;

        public ValuesController(HttpClient client)
        {
            _client = client;
        }

        public async Task<int> Get()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:14392/api/other"))
            {
                await _client.SendAsync(HttpContext, request, CancellationToken.None);
            }

            return 5;
        }
    }
}