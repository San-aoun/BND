using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BND_Testing.Helper
{
    public static class HttpClientFactoryHelperExtensions
    {
        public static FakeHttpMessageHandler AddHttpClientToReturnJson(
            this Mock<IHttpClientFactory> httpClientFactoryMock,
            string clientName,
            params string[] jsonArray)
        {
            List<HttpResponseMessage> httpResponseMessages = jsonArray.Select(json => new HttpResponseMessage
            {
                Content = new JsonContent(json)
            })
                .ToList();
            FakeHttpMessageHandler fakeHttpMessageHandler = new(httpResponseMessages);
            HttpClient httpClient = new(fakeHttpMessageHandler)
            {
                BaseAddress = new Uri("https://localhost")
            };
            httpClientFactoryMock
                .Setup(httpClientFactory => httpClientFactory.CreateClient(clientName))
                .Returns(httpClient);

            return fakeHttpMessageHandler;
        }

        public class FakeHttpMessageHandler : DelegatingHandler
        {
            private int _count;
            private readonly List<HttpResponseMessage> _httpResponseMessages;
            private readonly List<HttpRequestMessage> _httpRequestMessages = new();
            public IEnumerable<HttpRequestMessage> HttpRequestMessages => _httpRequestMessages;

            public FakeHttpMessageHandler(List<HttpResponseMessage> httpResponseMessages)
            {
                _httpResponseMessages = httpResponseMessages ?? throw new ArgumentNullException(nameof(httpResponseMessages));
            }

            protected override async Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request,
                CancellationToken cancellationToken
            )
            {
                _httpRequestMessages.Add(request);
                return await Task.FromResult(_httpResponseMessages[_count++]);
            }
        }

        public class JsonContent : StringContent
        {
            public JsonContent(string content) : base(content, Encoding.UTF8, "application/json")
            {
            }
        }

    }
}
