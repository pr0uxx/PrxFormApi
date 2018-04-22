using PrxFormApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrxFormApi.Data.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerByID(int CustomerId);
        IEnumerable<Customer> GetCustomerByUserID(string UserId);
        void InsertCustomer(Customer Customer);
        void DeleteCustomer(int CustomerID);
        void UpdateCustomer(Customer Customer);
        void Save();
    }
}
