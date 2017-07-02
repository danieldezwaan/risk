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
            new SeedCustomers().Seed(context, resourceName, assembly);
            new SeedEvents().Seed(context, resourceName, assembly);
            new SeedParticipants().Seed(context, resourceName, assembly);
            new SeedBets().Seed(context, resourceName, assembly, settled);
        }

    }
}