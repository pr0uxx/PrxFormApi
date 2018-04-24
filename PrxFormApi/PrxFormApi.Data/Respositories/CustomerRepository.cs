using PrxFormApi.Data.Context;
using PrxFormApi.Data.Models;
using PrxFormApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrxFormApi.Data.Respositories
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private DatabaseContext context;

        public CustomerRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<CustomerModel> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public CustomerModel GetCustomerByID(int id)
        {
            return context.Customers.Find(id);
        }

        public void InsertCustomer(CustomerModel Customer)
        {
            context.Customers.Add(Customer);
        }

        public void DeleteCustomer(int CustomerID)
        {
            CustomerModel Customer = context.Customers.Find(CustomerID);
            context.Customers.Remove(Customer);
        }

        public void UpdateCustomer(CustomerModel Customer)
        {
            context.Entry(Customer).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<CustomerModel> GetCustomerByUserID(string UserId)
        {
            return context.Customers.Where(x => x.UserId.Equals(UserId)).ToList();
        }
    }
}
