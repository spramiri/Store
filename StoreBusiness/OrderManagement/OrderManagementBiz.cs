using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace StoreBusiness.Order
{
    public class OrderManagementBiz
    {
        public static readonly OrderManagementBiz Instance = new OrderManagementBiz();

        public void AddProduct(int customerId, int ProductId)
        {
            using (var context = new StoreDataAccess.StoreDbContext())
            {
                using (var scope = context.Database.BeginTransaction())
                {
                    try
                    {
                        var order = context.Orders.FirstOrDefault(x => x.CustomerId == customerId);
                        if (order == null)
                        {
                            order = context.Orders.Add(new StoreModel.Models.Order
                            {
                                OrderDate = DateTime.Now,
                                PaymentStatus = false,
                                CustomerId = customerId
                            });
                            context.SaveChanges();
                        }

                        context.OrderProducts.Add(new StoreModel.Models.OrderProduct()
                        {
                            OrderId = order.OrderId,
                            ProductId = ProductId
                        });
                        context.SaveChanges();
                        scope.Commit();
                    }
                    catch (Exception e)
                    {
                        scope.Rollback();
                        throw e;
                    }
                }
            }
        }

        public StoreModel.Models.Order FindOrderByCustomerId(int customerId)
        {
            using(var context = new StoreDataAccess.StoreDbContext())
            {
                return context.Orders.Include(x=>x.OrderProducts).Include(x=>x.OrderProducts.Select(y=>y.Product)).FirstOrDefault(x => x.CustomerId == customerId);
            }
        }
    }
}
