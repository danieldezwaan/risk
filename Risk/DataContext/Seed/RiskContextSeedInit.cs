using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Risk.Models;
using System.IO;
using System.Reflection;
using CsvHelper;
using System.Text;
using System.Data.Entity.Migrations;

namespace Risk.DataContext.Seed
{
    /*
     * Populate seed data from csv files using Data.Entity.Migrations
     * Read csv resources using https://github.com/JoshClose/CsvHelper
     * */

    public class RiskContextSeedInit : DropCreateDatabaseAlways<RiskContext>
    {
        protected override void Seed(RiskContext context)
        {
            //inspect assembly using reflection to load csv resources
            Assembly assembly = Assembly.GetExecutingAssembly();

            /* uncomment next line to verify resource names */
            //var resources = assembly.GetManifestResourceNames();

            string resourceName = "Risk.DataContext.Seed.Settled.csv";
            csvSeed(context, resourceName, assembly, true);

            resourceName = "Risk.DataContext.Seed.Unsettled.csv";
            csvSeed(context, resourceName, assembly, false);
        }


        /*
         * Read a csv file and seed database
         * */
        private void csvSeed(RiskContext context, string resourceName, Assembly assembly, bool settled)
        {
            try
            {

                //create customers first
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        CsvReader csvReader = new CsvReader(reader);
                        //Avoid error on missing Id for example
                        csvReader.Configuration.WillThrowOnMissingField = false;
                        //Map customer id
                        csvReader.Configuration.RegisterClassMap<CsvCustomerMap>();
                        //Insert one row for each customer id
                        var customers = csvReader.GetRecords<Customer>()
                            .GroupBy(c => c.CustomerId)
                            .Select(c => c.First()).ToArray();
                        foreach (var c in customers)
                        {
                            context.Customers.AddOrUpdate(c);
                        }
                        context.SaveChanges();
                    }

                }

                //create events 
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

                //create participants   
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

                //create bets 
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
                throw new Exception("Error in csvSeed!", ex);
            }
        }

    }
}