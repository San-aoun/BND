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
                // seed produt 
                var product = new Product
                {
                    ProductType = table.Rows[i]["ProductType"],
                    ExternalAccount = table.Rows[i]["ExternalAccount"],
                };

                _fakeDBContext.Products.Add(product);
                _fakeDBContext.SaveChanges();

                // seed customer 
                var customer = new Customer
                {
                    CustomerFirstName = table.Rows[i]["CustomerFirstName"],
                    CustomerLastName = table.Rows[i]["CustomerLastName"],
                    CustomerEmail = table.Rows[i]["CustomerEmail"],
                };
                _fakeDBContext.Customers.Add(customer);
                _fakeDBContext.SaveChanges();

                // seed productCustomer 
                var ProductId = _fakeDBContext.Products.Single(p => p.ProductType == table.Rows[i]["ProductType"]).ProductId;
                var CustomerId = _fakeDBContext.Customers.Single(c => c.CustomerEmail == table.Rows[i]["CustomerEmail"]).CustomerId;

                var productCustomer = new ProductCustomer()
                {
                    ProductId = ProductId,
                    CustomerId = CustomerId,
                };
                _fakeDBContext.ProductCustomers.Add(productCustomer);
                _fakeDBContext.SaveChanges();

            }
        }
    }
}
