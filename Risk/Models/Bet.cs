using Risk.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Risk.Models
{
    public class Bet
    {
        [Key]
        public int          BetId { get; set; }

        //Foreign Keys
        public int          CustomerId { get; set; }
        public Customer     Customer
        {
            get
            {
                using (var context = new RiskContext())
                {
                    return context.Customers.Where(c => c.CustomerId == CustomerId).FirstOrDefault();
                }
            }
        }

        public int          EventId { get; set; }
        public Event Event
        {
            get
            {
                using (var context = new RiskContext())
                {
                    return context.Events.Where(e => e.EventId == EventId).FirstOrDefault();
                }
            }
        }

        public int          ParticipantId { get; set; }
        public Participant Participant
        {
            get
            {
                using (var context = new RiskContext())
                {
                    return context.Participants.Where(p => p.ParticipantId == ParticipantId).FirstOrDefault();
                }
            }
        }

        public decimal      Stake { get; set; }

        protected decimal?  _win;
        public decimal      Win
        {
            get
            {
                if (_win == null) _win = 0;
                return (decimal)_win;
            }
            set
            {
                if (value < 0) throw new Exception("Negative win amount invalid");
                _win = value;
            }
        }

        private bool? _settled;
        public bool         Settled
        {
            get
            {
                if (_settled == null) _settled = false;
                return (bool)_settled;
            }
            set
            {
                _settled = value;
            }
        }

    }
}