using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Risk.Models
{
    public class Customer
    {
        public int      CustomerId { get; set; }
        public string   Name { get; set; }
        public decimal  WinRate { get; set; }

    }
}