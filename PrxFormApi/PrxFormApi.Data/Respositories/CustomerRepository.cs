using PrxFormApi.Data.Context;
using PrxFormApi.Data.Entities;
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
        private CustomerContext context;

        public CustomerRepository(CustomerContext context)
        {
            this.context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public Customer GetCustomerByID(int id)
        {
            return context.Customers.Find(id);
        }

        public void InsertCustomer(Customer Customer)
        {
            context.Customers.Add(Customer);
        }

        public void DeleteCustomer(int CustomerID)
        {
            Customer Customer = context.Customers.Find(CustomerID);
            context.Customers.Remove(Customer);
        }

        public void UpdateCustomer(Customer Customer)
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

        public IEnumerable<Customer> GetCustomerByUserID(string UserId)
        {
            return context.Customers.Where(x => x.UserId.Equals(UserId)).ToList();
        }
    }
}
