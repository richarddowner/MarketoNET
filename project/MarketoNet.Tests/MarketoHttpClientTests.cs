using NUnit.Framework;

namespace MarketoNet.Tests
{
    [TestFixture]
    public class MarketoHttpClientTests
    {
        [Test]
        public async void LoginAsync()
        {
            using (var client = new MarketoNetHttpClient())
            {
                MarketoHttpResponse<MarketoBearerToken> response = await client.Login();
                response.AssertOk();

                Assert.NotNull(response.Value.AccessToken);
            }
        }
    }
}
