using PrxFormApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrxFormApi.Data.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerModel> GetCustomers();
        CustomerModel GetCustomerByID(int CustomerId);
        IEnumerable<CustomerModel> GetCustomerByUserID(string UserId);
        void InsertCustomer(CustomerModel Customer);
        void DeleteCustomer(int CustomerID);
        void UpdateCustomer(CustomerModel Customer);
        void Save();
    }
}
