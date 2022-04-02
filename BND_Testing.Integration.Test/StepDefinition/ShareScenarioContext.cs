using System.Net.Http;

namespace BND_Testing.Integration.Test.StepDefinition
{
    public class ShareScenarioContext
    {
        public HttpResponseMessage LatestResponseMessage { get; set; }
    }
}