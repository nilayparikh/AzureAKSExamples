using RestSharp;
using System;
using Xunit;

namespace API.IntegrationTests
{
    public class IntegrationTests
    {

        public RestClient consumerClient = default(RestClient);

        public IntegrationTests()
        {
            consumerClient = new RestClient("http://webapi");
        }

        [Fact]
        public void IntegrationTest1()
        {
            var inputId = "11";

            var requestToProvider = new RestRequest("/api/Consumer/{id}", Method.GET);
            requestToProvider.AddUrlSegment("id", inputId);

            var responseFromProvider = consumerClient.Execute(requestToProvider);
            var content = responseFromProvider.Content;

            Assert.Contains(inputId, content);
        }
    }
}
