using PrxFormApi.Data.Context;
using PrxFormApi.Data.Entities;
using PrxFormApi.Data.Repositories;
using PrxFormApi.Data.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Web;
using PrxFormApi.Models;
using Newtonsoft.Json;
using Microsoft.Owin.Host.SystemWeb;

namespace PrxFormApi.Controllers
{
    [Authorize]
    public class FormController : ApiController
    {
        private ICustomerRepository customerRepository;

        public FormController()
        {
            this.customerRepository = new CustomerRepository(new CustomerContext());
        }

        public FormController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [Throttle(Message = "You must wait 60 seconds befor adding a new customer", Name ="AddCustomerThrottle", Seconds = 60)]
        [AllowAnonymous]
        [Route("api/Form/AddCustomer")]
        public IHttpActionResult AddCustomer(Customer customer, string email)
        {
            //var userId = User.Identity.GetUserId();

            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByEmail(email);
            customer.UserId = user.Id;

            if (user.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    customerRepository.InsertCustomer(customer);
                    customerRepository.Save();
                    return Content(HttpStatusCode.OK, "");
                }
                catch (Exception ex)
                {
                    return Content(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            else
            {
                return Content(HttpStatusCode.Forbidden, "Invalid Email");
            }

            
        }

        [Route("api/Form/GetAllCustomers")]
        public IHttpActionResult GetCustomers()
        {
            var userId = User.Identity.GetUserId();

            var customers = customerRepository.GetCustomerByUserID(userId);

            if (customers.Count() > 0)
            {
                var result = JsonConvert.SerializeObject(customers);

                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NoContent, "No results");
            }
        }
    }
}
