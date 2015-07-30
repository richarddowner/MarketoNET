using System.Threading.Tasks;
using NUnit.Framework;

namespace MarketoNet.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected async Task<MarketoNetHttpClient> EnsureLoggedIn()
        {
            var settings = new MarketoHttpClientSettings();
            var client = new MarketoNetHttpClient(settings);

            MarketoHttpResponse<MarketoBearerToken> login = await client.Login();

            client.SetBearerToken(login.Value);

            return client;
        } 
    }
}