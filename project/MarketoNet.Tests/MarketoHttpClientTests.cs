using System;
using NUnit.Framework;

namespace MarketoNet.Tests
{
    [TestFixture]
    public class MarketoHttpClientTests : BaseTest
    {
        [Test]
        public async void LoginAsyncTest()
        {
            using (var client = new MarketoNetHttpClient())
            {
                MarketoHttpResponse<MarketoBearerToken> response = await client.Login();
                response.AssertOk();

                Assert.NotNull(response.Value.AccessToken);
            }
        }

        [Test]
        public void EnsureLoggedInTest()
        {
            using (MarketoNetHttpClient client = EnsureLoggedIn().Result)
            {
                Assert.NotNull(client.BearerToken.AccessToken);
            }
        }
    }
}
