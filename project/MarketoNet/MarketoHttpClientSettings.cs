using System;
using System.Configuration;

namespace MarketoNet
{
    public class MarketoHttpClientSettings
    {
        private string clientId;
        private string clientSecret;
        private Uri authUri;
        private Uri apiUri;

        public MarketoHttpClientSettings(string clientId = null, string clientSecret = null, Uri authUri = null, Uri apUri = null)
        {
            AuthUri = authUri ?? new Uri(ConfigurationManager.AppSettings["marketo:authuri"]);
            ApiUri = apiUri ?? new Uri(ConfigurationManager.AppSettings["marketo:apiuri"]);

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

        public Uri ApiUri
        {
            get { return apiUri; }
            private set
            {
                if (value == null) throw new ArgumentNullException("value");
                apiUri = value;
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