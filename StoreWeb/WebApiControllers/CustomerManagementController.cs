using StoreModel.Models;
using StoreModel.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StoreWep.Controllers
{
    public class CustomerManagementController : ApiController
    {
        // POST: api/CustomerManagement
        public int Post([FromBody] Customer customer)
        {
            return StoreBusiness.Product.CustomerManagementBiz.Instance.Add(customer).CustomerId;
        }
    }
}
