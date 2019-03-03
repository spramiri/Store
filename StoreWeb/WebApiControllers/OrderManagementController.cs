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
    public class OrderManagementController : ApiController
    {
        // GET: api/OrderManagement
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OrderManagement/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OrderManagement
        public void Post([FromBody] CustomerProduct customerProduct)
        {
            StoreBusiness.Order.OrderManagementBiz.Instance.AddProduct(customerProduct.CustomerId, customerProduct.ProductId);
        }
        
        // DELETE: api/OrderManagement/5
        public void Delete(int id)
        {
        }
    }
}
