using Risk.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk.Specs
{
    public abstract class StepBase
    {

        public RiskContext context = new DataContext.RiskContext();

    }
}
