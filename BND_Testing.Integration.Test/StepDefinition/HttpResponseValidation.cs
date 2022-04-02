using BND_Testing.DBModel.FakeDB;
using BND_Testing.Dto;
using BND_Testing.Integration.Test.StartUp;
using BND_Testing.Model;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace BND_Testing.Integration.Test.StepDefinition
{
    [Binding]
    public class HttpResponseValidation : BaseStepDefinition
    {
        public HttpResponseValidation(LocalServerFactory<Startup> factory,ShareScenarioContext shareScenarioContext, FakeDB fakeDBContext)
        : base(factory, shareScenarioContext, fakeDBContext) { }

        [Then(@"the system gets a response with code ""(.*)""")]
        [Then(@"the user gets a response with code ""(.*)""")]
        public void TheUserGetsAResponseWithCodeMessage(int statusCode)
        {
            Assert.Equal(statusCode, (int)LatestResponseMessage.StatusCode);
        }

        [Then(@"the user gets data details response with values")]
        public async Task ThenTheUserGetsDataDetailsResponseWithValues(Table table)
        {
            await AssertInstanceFromResponseWithTable<MovementDto>(table);
        }

        [Then(@"the user gets movment details response with values")]
        public async Task ThenTheUserGetsMovmentDetailsResponseWithValues(Table table)
        {
            await AssertInstanceFromResponseWithTable<MovementResponse>(table);
        }
    }
}
