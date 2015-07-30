using System;
using MarketoNet.Response;
using NUnit.Framework;

namespace MarketoNet.Tests
{
    public static class MarketoHttpResponseAssertions
    {
        public static void AssertOk(this MarketoHttpResponse response)
        {
            Assert.NotNull(response);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content);
            }

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        public static void AssertOk<T>(this MarketoHttpResponse<T> response)
        {
            Assert.NotNull(response);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content);
            }

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.NotNull(response.Value);
        }
    }
}