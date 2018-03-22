using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ConsumerController : Controller
    {
        public RestClient ProviderClient = default(RestClient);
        public IConfiguration Configuration = default(IConfiguration);

        public ConsumerController(IConfiguration configuration)
        {
            Configuration = configuration;

            ProviderClient = new RestClient("http://corewebapi");
        }

        // GET api/values/5
        // Logic changed
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var requestToProvider = new RestRequest("/api/Provider/{id}", Method.GET);
            requestToProvider.AddUrlSegment("id", id);

            var responseFromProvider = ProviderClient.Execute(requestToProvider);
            var content = responseFromProvider.Content;

            return "Response from provider 1 " + content;
        }
    }
}
