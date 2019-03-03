using StoreModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBusiness.Product
{
    public class CustomerManagementBiz
    {
        public static readonly CustomerManagementBiz Instance = new CustomerManagementBiz();

        public Customer Add(Customer Customer)
        {
            using (var context = new StoreDataAccess.StoreDbContext())
            {
                Customer = context.Customers.Add(Customer);
                context.SaveChanges();
                return Customer;
            }
        }
    }
}
