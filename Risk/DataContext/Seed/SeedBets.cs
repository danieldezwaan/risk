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
    public class SeedBets : ICsvSeedBet
    {
        public void Seed(RiskContext context, string resourceName, Assembly assembly, bool settled)
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
                        //Map customer id
                        csvReader.Configuration.RegisterClassMap<CsvBetMap>();
                        //Set the settled bit
                        var bets = csvReader.GetRecords<Bet>().Select(b => { b.Settled = settled; return b; }).ToArray();
                        context.Bets.AddRange(bets);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error seeding bets", ex);
            }
        }
    }
}