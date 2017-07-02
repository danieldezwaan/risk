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
    public class SeedEvents : ICsvSeed
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
                        csvReader.Configuration.RegisterClassMap<CsvEventMap>();
                        //Insert one row for each event id
                        var events = csvReader.GetRecords<Event>()
                            .GroupBy(e => e.EventId)
                            .Select(e => e.First()).ToArray();
                        foreach (var e in events)
                        {
                            context.Events.AddOrUpdate(e);
                        }
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error seeding events", ex);
            }
        }
    }
}