﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Risk.DataContext.Seed
{
    interface ICsvSeedBet
    {
        void Seed(RiskContext context, string resourceName, Assembly assembly, bool settled);
    }
}
