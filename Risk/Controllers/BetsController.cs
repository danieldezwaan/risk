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

namespace Risk.Controllers
{
    public class BetsController : Controller
    {
        private RiskContext db = new RiskContext();

        // GET: BetsView
        //Only including unsettled bets to meet display requirements
        public ActionResult Index()
        {
            var bets = db.Bets.Where(b => b.Settled == false).ToList();
            foreach (var bet in bets)
            {
                if (bet.Customer == null)
                {
                    bet.Customer = db.Customers.Where(c => c.CustomerId == bet.CustomerId).FirstOrDefault();
                }
            }
            return View(bets);
        }

        // GET: BetsView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bet bet = db.Bets.Find(id);
            if (bet == null)
            {
                return HttpNotFound();
            }
            return View(bet);
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
