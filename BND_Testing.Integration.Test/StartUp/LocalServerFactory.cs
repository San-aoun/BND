using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System.Net.Http;

namespace BND_Testing.Integration.Test.StartUp
{
    public class LocalServerFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
        public LocalServerFactory()
        {
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
        }
    }

}
