using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Risk.DataContext;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Risk.Models
{
    public class Customer
    {
        //do not set identity column, instead import from csv
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int      CustomerId { get; set; }
        public string   Name { get; set; }

        private decimal _winRate;
        public decimal  WinRate
        {
            get
            {
                //win rate = ratio of settled bets won
                using (var context = new RiskContext())
                {
                    int betsWon = context.Bets
                        .Where(b => b.CustomerId == CustomerId && b.Settled == true && b.Win > 0)
                        .Count();
                    if (betsWon == 0)
                    {
                        _winRate = 0;
                    }
                    else
                    {
                        int settledBets = context.Bets
                            .Where(b => b.CustomerId == CustomerId && b.Settled == true)
                            .Count();
                        _winRate = (decimal)betsWon / settledBets;
                    }
                }
                return _winRate;
            }
            set
            {
                _winRate = value;
            }
        }

        private decimal? _averageBet;
        public decimal  AverageBet
        {
            get
            {
                //win rate = ratio of settled bets won
                using (var context = new RiskContext())
                {
                    if (context.Bets
                            .Where(b => b.CustomerId == CustomerId)
                            .Count() == 0)
                    {
                        _averageBet = 0;
                    }
                    else
                    {
                        _averageBet = context.Bets
                        .Where(b => b.CustomerId == CustomerId)
                        .Average(b => b.Stake);
                    }
                }
                if (_averageBet == null) _averageBet = 0;
                return (decimal)_averageBet;
            }
            set
            {
                _averageBet = value;
            }
        }

        



    }
}