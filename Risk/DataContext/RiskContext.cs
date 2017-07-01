using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Risk.Models;
using Risk.DataContext.Seed;
using System.Data.Entity.Core.Objects;

namespace Risk.DataContext 
{
    public class RiskContext : DbContext
    {
        public DbSet<Customer>      Customers { get; set; }
        public DbSet<Event>         Events { get; set; }
        public DbSet<Participant>   Participants { get; set; }
        public DbSet<Bet>           Bets { get; set; }

    }
}