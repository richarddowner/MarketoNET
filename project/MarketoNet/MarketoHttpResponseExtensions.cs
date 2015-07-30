using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MarketoNet.Response;
using Newtonsoft.Json;

namespace MarketoNet
{
    public static class MarketoHttpResponseExtensions
    {
        public static async Task<MarketoHttpResponse<T>> ToMarketoResponseAsync<T>(this HttpResponseMessage httpResponse)
        {
            if (httpResponse == null) throw new ArgumentNullException("httpResponse");

            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            var response = new MarketoHttpResponse<T>
            {
                Content = responseContent,
                IsSuccessStatusCode = httpResponse.IsSuccessStatusCode,
                StatusCode = httpResponse.StatusCode,
                Headers = httpResponse.Headers,
                HttpResponse = httpResponse,
                Errors = new Dictionary<string, string>()
            };

            if (httpResponse.IsSuccessStatusCode)
            {
                response.Value = await httpResponse.Content.ReadAsAsync<T>();
            }
            else
            {
                ExtractErrors(responseContent, response);
            }

            return response;
        }

        private static void ExtractErrors(string responseContent, MarketoHttpResponse response)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(responseContent);

            if (data.ContainsKey("type"))
            {
                var errorType = data["type"].ToString();

                if (data.ContainsKey("details"))
                {
                    var errorDetails = data["details"].ToString();
                    response.Errors.Add(errorType, errorDetails);
                }

                if (data.ContainsKey("detail"))
                {
                    var detail = data["detail"].ToString();
                    response.Errors.Add(errorType, detail);
                }
            }
        }
    }
}