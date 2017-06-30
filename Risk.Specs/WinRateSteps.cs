using System;
using TechTalk.SpecFlow;

namespace Risk.Specs
{
    [Binding]
    public class WinRateSteps
    {
        [Given(@"The average win rate for a customer is greater than (.*)")]
        public void GivenTheAverageWinRateForACustomerIsGreaterThan(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"The average win rate is calculated")]
        public void WhenTheAverageWinRateIsCalculated()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The customer win percentage value should equal the win rate")]
        public void ThenTheCustomerWinPercentageValueShouldEqualTheWinRate()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
