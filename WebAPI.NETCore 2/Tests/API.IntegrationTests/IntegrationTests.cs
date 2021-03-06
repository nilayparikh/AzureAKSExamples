using RestSharp;
using System;
using Xunit;

namespace API.IntegrationTests
{
    public class IntegrationTests
    {

        public RestClient consumerClient = default(RestClient);
        public RestClient providerClient = default(RestClient);

        public IntegrationTests()
        {
            consumerClient = new RestClient("http://webapi");
            providerClient = new RestClient("http://corewebapi");
        }

        [Fact]
        public void IntegrationTest1()
        {
            var inputId = "11";

            var requestToConsumer = new RestRequest("/api/Consumer/{id}", Method.GET);
            requestToConsumer.AddUrlSegment("id", inputId);

            var responseFromConsumer = consumerClient.Execute(requestToConsumer);
            var content = responseFromConsumer.Content;

            Assert.True(true);
        }

        [Fact]
        public void IntegrationTest2()
        {
            var inputId = "11";

            var requestToProvider = new RestRequest("/api/Provider/{id}", Method.GET);
            requestToProvider.AddUrlSegment("id", inputId);

            var responseFromProvider = providerClient.Execute(requestToProvider);
            var content = responseFromProvider.Content;

            Assert.True(true);
        }
    }
}
