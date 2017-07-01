using CsvHelper.Configuration;
using Risk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Risk.DataContext.Seed
{
    sealed class CsvCustomerMap : CsvClassMap<Customer>
    {
        public CsvCustomerMap()
        {
            Map(m => m.CustomerId).Name("Customer");
        }
        
    }
}