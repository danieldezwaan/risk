using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CsvHelper.Configuration;
using Risk.Models;

namespace Risk.DataContext.Seed
{
    sealed class CsvBetMap : CsvClassMap<Bet>
    {
        public CsvBetMap()
        {
            Map(m => m.CustomerId).Name("Customer");
            Map(m => m.EventId).Name("Event");
            Map(m => m.ParticipantId).Name("Participant");
            Map(m => m.Stake).Name("Stake");
            Map(m => m.Win).Name("Win");
        }
    }
}