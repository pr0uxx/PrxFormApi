using PrxFormApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrxFormApi.Data.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);

            var customer = new CustomerModel()
            {
                City = "London",
                Telephone = "0800047510",
                Country = "United Kingdom",
                Email = "email@email.com",
                CustomerId = 1,
                FirstName = "Steve",
                LastName = "Smith",
                Message = "This is a test message!",
                UserId = "Seed"
            };


            context.Customers.Add(customer);
            context.SaveChanges();
        }
    }
}
