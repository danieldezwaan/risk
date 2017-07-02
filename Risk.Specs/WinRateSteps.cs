using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace Risk.Specs
{
    [Binding]
    public class WinRateSteps : StepBase
    {
        [Given(@"The data seed process is complete")]
        public void GivenTheDataSeedProcessIsComplete()
        {
            //Data context is loaded in base class
        }
        
        [Then(@"Customer (.*) win percentage value should equal (.*)")]
        public void ThenCustomerWinPercentageValueShouldEqual(int p0, Decimal p1)
        {
            Assert.AreEqual(context.Customers.Find(p0).WinRate, p1);
        }
    }
}
