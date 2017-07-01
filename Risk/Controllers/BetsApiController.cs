using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Risk.DataContext;
using Risk.Models;

namespace Risk.Controllers
{
    public class BetsApiController : ApiController
    {
        private RiskContext db = new RiskContext();

        // GET: api/Bets
        public IQueryable<Bet> GetBets()
        {
            return db.Bets;
        }

        // GET: api/Bets/5
        [ResponseType(typeof(Bet))]
        public IHttpActionResult GetBet(int id)
        {
            Bet bet = db.Bets.Find(id);
            if (bet == null)
            {
                return NotFound();
            }

            return Ok(bet);
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BetExists(int id)
        {
            return db.Bets.Count(e => e.BetId == id) > 0;
        }
    }
}