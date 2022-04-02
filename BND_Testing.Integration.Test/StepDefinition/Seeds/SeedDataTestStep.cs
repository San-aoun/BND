using BND_Testing.DBModel.FakeDB;
using BND_Testing.Integration.Test.StartUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BND_Testing.Integration.Test.StepDefinition.Seeds
{
    [Binding]
    public class SeedDataTestStep : BaseStepDefinition
    {
        public SeedDataTestStep(LocalServerFactory<Startup> factory, 
            ShareScenarioContext shareScenarioContext, FakeDB fakeDBContext)
        : base(factory, shareScenarioContext, fakeDBContext) { }

        [Given(@"Set up data with details")]
        public void GivenSetUpDataWithDetails(Table table)
        {
            for (var i = 0; i < table.RowCount; i++)
            {
                var productCustomer = new ProductCustomer()
                {
                    ProductId = int.Parse(table.Rows[i]["ProductId"]),
                    Product = new Product
                    {
                        ProductType = table.Rows[i]["ProductType"],
                        ExternalAccount = table.Rows[i]["ExternalAccount"],
                    },
                    Customer = new Customer
                    {
                        CustomerFirstName = table.Rows[i]["CustomerFirstName"],
                        CustomerLastName = table.Rows[i]["CustomerLastName"],
                        CustomerEmail = table.Rows[i]["CustomerEmail"],
                    }

                };
                _fakeDBContext.ProductCustomers.Add(productCustomer);


            }
            _fakeDBContext.SaveChanges();
        }
    }
}
