using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Customer     Customer { get; set; }

        public int          EventId { get; set; }
        public Event        Event { get; set; }

        public int          ParticipantId { get; set; }
        public Participant  Participant { get; set; }

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