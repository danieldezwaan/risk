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
    public class SeedCustomers : ICsvSeed
    {
        public void Seed(RiskContext context, string resourceName, Assembly assembly)
        {
            try
            {
                //create customers 
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
            }
            catch (Exception ex)
            {
                throw new Exception("Error seeding customers", ex);
            }

        }
    }
}