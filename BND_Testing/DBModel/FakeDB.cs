using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace BND_Testing.DBModel.FakeDB
{
    public class FakeDB : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCustomer> ProductCustomers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
    public class Product
    { 
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public string ExternalAccount { get; set; }
    }
    public class ProductCustomer
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    
    }
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
    }

    


}
