using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jacaranda.Utilities.Test
{
    [TestClass]
    public class HttpRequestMessageExtensionTest
    {
        [TestMethod]
        public void GetRequestBodyStringTest()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/post");
            var bodyString = "{ \"data\": \"test data\" }";
            request.Content = new StringContent(bodyString);

            Assert.AreEqual(request.GetBodyString(), bodyString);
        }

        [TestMethod]
        public void GetRequestBodyStringAsyncTest()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/post");
            var bodyString = "{ \"data\": \"test data\" }";
            request.Content = new StringContent(bodyString);

            Assert.AreEqual(request.GetBodyStringAsync().Result, bodyString);
        }
    }
}
