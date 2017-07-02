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

        //win rate = ratio of settled bets won
        public decimal  WinRate
        {
            get
            {
                return calcWinRate();
            }
        }
        
        //win rate = ratio of settled bets won
        public decimal  AverageBet
        {
            get
            {
                return calcAverageBet();
            }
        }

        private decimal calcAverageBet()
        {
            using (var context = new RiskContext())
            {
                if (context.Bets
                        .Where(b => b.CustomerId == CustomerId)
                        .Count() == 0)
                {
                    return 0;
                }
                else
                {
                    return (decimal)context.Bets
                    .Where(b => b.CustomerId == CustomerId)
                    .Average(b => b.Stake);
                }
            }
        }


        private decimal calcWinRate()
        {
            using (var context = new RiskContext())
            {
                int betsWon = context.Bets
                    .Where(b => b.CustomerId == CustomerId && b.Settled == true && b.Win > 0)
                    .Count();
                if (betsWon == 0)
                {
                    return 0;
                }
                else
                {
                    int settledBets = context.Bets
                        .Where(b => b.CustomerId == CustomerId && b.Settled == true)
                        .Count();
                    return (decimal)betsWon / settledBets;
                }
            }
        }


    }
}