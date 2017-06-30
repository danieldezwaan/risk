using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Risk.DataContext;
using Risk.Models;
using System.Web.Http;

namespace Risk.Controllers
{
    public class CustomersController : ApiController
    {
        private RiskContext db = new RiskContext();

        // GET: Customers
        public IEnumerable<Customer> Get()
        {
            //return View(db.Customers.ToList());
            return db.Customers.ToList();
        }

        // GET api/customers/5
        public Customer Get(int id)
        {
            return db.Customers.Where(i => i.CustomerId == id).FirstOrDefault();
        }

    }
}
