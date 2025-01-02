using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Assessment_1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        
        private NorthwindEntities db = new NorthwindEntities(); 

        public ActionResult CustomersInGermany()
        {
            var customers = db.Customers
                .Where(c => c.Country == "Germany")
                .ToList();

            return View(customers); 
        }

        public ActionResult CustomerDetailsByOrderId(int id = 10248)
        {
            var customerWithOrder = (from o in db.Orders
                                     where o.OrderID == id
                                     join c in db.Customers on o.CustomerID equals c.CustomerID
                                     select new
                                     {
                                         Customer = c,
                                         Order = o
                                     }).FirstOrDefault();

            return View(customerWithOrder); 
        }
    }

    internal class NorthwindEntities
    {
    }
}
