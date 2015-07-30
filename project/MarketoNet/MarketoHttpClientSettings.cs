using System;
using System.Configuration;

namespace MarketoNet
{
    public class MarketoHttpClientSettings
    {
        private string clientId;
        private string clientSecret;
        private Uri authUri;

        public MarketoHttpClientSettings(string clientId = null, string clientSecret = null, Uri authUri = null)
        {
            AuthUri = authUri ?? new Uri("https://232-OQW-357.mktorest.com/identity/");

            ClientId = clientId ?? ConfigurationManager.AppSettings["marketo:clientid"];
            ClientSecret = clientSecret ?? ConfigurationManager.AppSettings["marketo:clientsecret"];

            if (string.IsNullOrEmpty(ClientId)) throw new ArgumentNullException("clientId");
            if (string.IsNullOrEmpty(ClientSecret)) throw new ArgumentNullException("clientSecret");
        }

        public string ClientId
        {
            get { return clientId; }
            private set
            {
                if (value == null) throw new ArgumentNullException("value");
                clientId = value;
            }
        }

        public string ClientSecret
        {
            get { return clientSecret; }
            private set
            {
                if (value == null) throw new ArgumentNullException("value");
                clientSecret = value;
            }
        }

        public Uri AuthUri
        {
            get { return authUri; }
            private set
            {
                if (value == null) throw new ArgumentNullException("value");
                authUri = value;
            }
        }
    }
}