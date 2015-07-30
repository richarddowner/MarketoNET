using System.Collections.Generic;

namespace MarketoNet
{
    public class MarketoBearerToken : Dictionary<string, string>
    {
        public string AccessToken
        {
            get { return this["access_token"]; }
            set { this["access_token"] = value; }
        }

        public string RefreshToken
        {
            get { return this["refresh_token"]; }
            set { this["refresh_token"] = value; }
        }
    }
}