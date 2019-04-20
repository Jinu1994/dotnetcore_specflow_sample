using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using TechTalk.SpecFlow;
using Xunit;

namespace DotnetCoreBddExample.Tests.StepDefinitions
{
    [Binding]
    public class UsersResourceSteps : IClassFixture<WebApplicationFactory<TestStartup>>
    {
        private WebApplicationFactory<TestStartup> _factory;
        
        /// <summary>
        /// Gets or sets the http client used to make the request
        /// </summary>
        /// <value>The http client</value>
        private HttpClient _client { get; set; }

        /// <summary>
        /// Gets or sets the api response
        /// </summary>
        /// <value>The http response</value>
        protected HttpResponseMessage Response { get; set; }
        public UsersResourceSteps(WebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }
        [Given(@"I am a client")]
        public void GivenIAmAClient()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"http://localhost/")
            });
        }
        
        [When(@"I make a post request to '(.*)' with the following data '(.*)'")]
        public virtual async Task WhenIMakeAPostRequestToWithTheFollowingData(string resourceEndPoint, string postDataJson)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = new StringContent(postDataJson, Encoding.UTF8, "application/json");
            Response = await _client.PostAsync(postRelativeUri, content).ConfigureAwait(false);
        }


        [Then(@"the response status code is '(.*)'")]
        public void ThenTheResponseStatusCodeIs(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }


        [Then(@"the response data should be '(.*)'")]
        public void ThenTheResponseDataShouldBe(string expectedResponse)
        {
            var responseData = Response.Content.ReadAsStringAsync().Result;
            Assert.Equal(expectedResponse, responseData);
        }

    }
}
