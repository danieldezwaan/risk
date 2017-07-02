using CsvHelper;
using Risk.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Data.Entity.Migrations;

namespace Risk.DataContext.Seed
{
    public class SeedParticipants : ICsvSeed
    {
        public void Seed(RiskContext context, string resourceName, Assembly assembly)
        {
            try
            {
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        CsvReader csvReader = new CsvReader(reader);
                        //Avoid error on missing Id for example
                        csvReader.Configuration.WillThrowOnMissingField = false;
                        //Map event id
                        csvReader.Configuration.RegisterClassMap<CsvParticipantMap>();
                        //Insert one row for each participant id
                        var participants = csvReader.GetRecords<Participant>()
                            .GroupBy(p => p.ParticipantId)
                            .Select(p => p.First()).ToArray();
                        foreach (var p in participants)
                        {
                            context.Participants.AddOrUpdate(p);
                        }
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error seeding participants", ex);
            }
        }
    }
}