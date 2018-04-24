using Microsoft.AspNet.Identity.EntityFramework;
using PrxFormApi.Data.Models;
using PrxFormApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrxFormApi.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(string databaseConnection) : base()
        {
            this.Database.Connection.ConnectionString = databaseConnection;
        }

        public DbSet<CustomerModel> Customers { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(string databaseConnection)
            : base(databaseConnection, throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create(string databaseConnection)
        {
            return new ApplicationDbContext(databaseConnection);
        }
    }
}
