using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CsvHelper.Configuration;
using Risk.Models;

namespace Risk.DataContext.Seed
{
    sealed class CsvEventMap : CsvClassMap<Event>
    {
        public CsvEventMap()
        {
            Map(m => m.EventId).Name("Event");
        }
    }
}