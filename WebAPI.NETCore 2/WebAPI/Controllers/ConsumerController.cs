using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ConsumerController : Controller
    {
        public RestClient providerClient = default(RestClient);

        public ConsumerController()
        {
            providerClient = new RestClient("http://corewebapi");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var requestToProvider = new RestRequest("/api/Provider/{id}", Method.GET);
            requestToProvider.AddUrlSegment("id", id);

            var responseFromProvider = providerClient.Execute(requestToProvider);
            var content = responseFromProvider.Content;

            return "Response from provider " + content;
        }
    }
}
