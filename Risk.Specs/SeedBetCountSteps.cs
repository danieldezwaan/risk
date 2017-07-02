using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using System.Linq;

namespace Risk.Specs
{
    [Binding]
    public class SeedBetCountSteps : StepBase
    {
        [Given(@"Bets have been imported from csv")]
        public void GivenBetsHaveBeenImportedFromCsv()
        {
            //Data context is loaded in base class
        }

        [Then(@"the count should be (.*)")]
        public void ThenTheCountShouldBe(int p0)
        {
            Assert.AreEqual(context.Bets.Count(), p0);
        }
    }
}
