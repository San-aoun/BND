using BND_Testing.DBModel.FakeDB;
using BND_Testing.Integration.Test.StartUp;
using System.Linq;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace BND_Testing.Integration.Test.StepDefinition.Domain
{
    [Binding]
    public class MovementStep : BaseStepDefinition
    {
        public MovementStep(LocalServerFactory<Startup> factory,
            ShareScenarioContext shareScenarioContext, FakeDB fakeDBContext)
        : base(factory, shareScenarioContext, fakeDBContext) { }

        [When(@"the user gets movement detial with by Product Type ""([^""]*)"" and fillterType ""([^""]*)""")]
        public async void WhenUserGetsMovementDetialWithByProductId(string productType, string filterType)
        {
            var productId = _fakeDBContext.Products.Single(p => p.ProductType == productType).ProductId;

            string url = $"{HttpClientBaseAddress}" + $"/movments/{productId}/{filterType}";

            using HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            await SendAsync(requestMessage);
        }


    }
}
