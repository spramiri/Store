using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace StoreBusiness.Product
{
    public class ProductBiz
    {
        public static readonly ProductBiz Instance = new ProductBiz(); 

        public List<StoreModel.Models.Product> FindAllProducts()
        {
            using (var context = new StoreDataAccess.StoreDbContext())
            {
                return context.Products.Include(x => x.ProductDetails).ToList();
            }
        }
    }
}
