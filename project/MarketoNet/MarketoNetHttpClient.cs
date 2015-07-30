using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace MarketoNet
{
    public class MarketoNetHttpClient : IDisposable
    {
        private MarketoHttpClientSettings settings;
        private HttpClient httpClient;
        private JsonMediaTypeFormatter jsonFormatter;
        private MarketoBearerToken bearerToken;

        public MarketoNetHttpClient() 
            : this(new MarketoHttpClientSettings())
        {
        }

        public MarketoNetHttpClient(MarketoHttpClientSettings settings)
        {
            Settings = settings;
            HttpClient = new HttpClient();
            JsonFormatter = new JsonMediaTypeFormatter();
        }

        public MarketoHttpClientSettings Settings
        {
            get { return settings; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                settings = value;
            }
        }

        public HttpClient HttpClient
        {
            get { return httpClient; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                httpClient = value;
            }
        }

        public JsonMediaTypeFormatter JsonFormatter
        {
            get { return jsonFormatter; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                jsonFormatter = value;
            }
        }

        public MarketoBearerToken BearerToken
        {
            get { return bearerToken; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                bearerToken = value;

                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + bearerToken.AccessToken);
            }
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }

        public async Task<MarketoHttpResponse<MarketoBearerToken>> Login()
        {
            var values = new Dictionary<string, string>
            {
                {"grant_type", "client_credentials"},
                {"client_id", settings.ClientId},
                {"client_secret", settings.ClientSecret},
            };

            var content = new FormUrlEncodedContent(values);

            HttpResponseMessage httpResponse = await httpClient.PostAsync(settings.AuthUri + "oauth/token", content);

            MarketoHttpResponse<MarketoBearerToken> response = await httpResponse.ToMarketoResponseAsync<MarketoBearerToken>();

            return response;
        }

        public void SetBearerToken(MarketoBearerToken value)
        {
            BearerToken = value;
        }
    }
}
