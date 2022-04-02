using BND_Testing.DBModel.FakeDB;
using BND_Testing.Integration.Test.StartUp;
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

        [When(@"user gets movement detial with by product id ""([^""]*)""")]
        public async void WhenUserGetsMovementDetialWithByProductId(string productId)
        {
            string url = $"{HttpClientBaseAddress}" + $"/movments/{productId}";

            using HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            await SendAsync(requestMessage);
        }


    }
}
