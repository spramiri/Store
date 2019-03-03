using StoreModel.Models;
using StoreModel.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SystemWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productList = StoreBusiness.Product.ProductBiz.Instance.FindAllProducts();
            return View(productList);
        }

        public async Task<ActionResult> AddToBasket(int ProductId)
        {

            using (HttpClient client = new HttpClient())
            {
                int CustomerId = Convert.ToInt32(System.Web.HttpContext.Current.Session["CustomerId"]);

                if (CustomerId == 0)
                {
                    var customerResponse = await client.PostAsJsonAsync("http://localhost:11135/api/CustomerManagement", new Customer() { });
                    customerResponse.EnsureSuccessStatusCode(); // Throw if not a success code.
                    if (customerResponse.IsSuccessStatusCode)
                    {
                        var customerResult = await customerResponse.Content.ReadAsStringAsync();
                        if (!int.TryParse(customerResult, out CustomerId))
                            throw new Exception("خطا در ثبت مشتری");
                    }
                    System.Web.HttpContext.Current.Session["CustomerId"] = CustomerId;
                }
                var result = await client.PostAsJsonAsync("http://localhost:11135/Api/OrderManagement", new CustomerProduct { CustomerId = CustomerId, ProductId = ProductId });

                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Cart()
        {
            int CustomerId = Convert.ToInt32(System.Web.HttpContext.Current.Session["CustomerId"]);

            var order = StoreBusiness.Order.OrderManagementBiz.Instance.FindOrderByCustomerId(CustomerId);
            return View(order);
        }
    }
}