using BND_Testing.DBModel.FakeDB;
using BND_Testing.Integration.Test.StartUp;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace BND_Testing.Integration.Test.StepDefinition
{
    [Binding]
    public class BaseStepDefinition : IClassFixture<LocalServerFactory<Startup>>
    {
        private readonly ShareScenarioContext _shareScenarioContext;
        protected HttpClient _apiClients;
        protected LocalServerFactory<Startup> _httpClientFactory;
        protected readonly FakeDB _fakeDBContext;
        public BaseStepDefinition(
            LocalServerFactory<Startup> factory, ShareScenarioContext shareScenarioContext, FakeDB fakeDBContext)
        {
            _httpClientFactory = factory;
            _shareScenarioContext = shareScenarioContext;
            _fakeDBContext = fakeDBContext;

            _apiClients = factory.CreateClient();
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage)
        {
            var httpResponseMessage = await _apiClients.SendAsync(requestMessage);
            _shareScenarioContext.LatestResponseMessage = httpResponseMessage;

            return _shareScenarioContext.LatestResponseMessage;
        }

        protected HttpResponseMessage LatestResponseMessage => _shareScenarioContext.LatestResponseMessage;

        protected Uri HttpClientBaseAddress => _apiClients.BaseAddress;

        #region DeserializeResponse
        protected async Task<T> DeserializeResponse<T>()
        {
            var responseContent = await LatestResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }
        protected async Task AssertInstanceFromResponseWithTable<T>(Table table)
        {
            var content = await DeserializeResponse<T>();
            table.CompareToInstance(content);
        }
        #endregion
    }

}
