using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CsvHelper.Configuration;
using Risk.Models;

namespace Risk.DataContext.Seed
{
    sealed class CsvParticipantMap : CsvClassMap<Participant>
    {
        public CsvParticipantMap()
        {
            Map(m => m.ParticipantId).Name("Participant");
        }
    }
}