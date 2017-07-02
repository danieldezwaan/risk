# risk

Simple risk application highlights high risk customers and wagers

## Project features
			- EntityFramework code first approach
			- Example data seeded from csv files
			- Cucumber tests written in Gherkin and implemeted with SpecFlow

## UI requirements
Highlight:
- customers that win on >60% of bets
- bets of customers that win on >60% of bets
- bets where the stake is > 10 * customer average bet
- bets where the stake is > 30 * customer average bet
- bets where the stake is > 1000
			
## Configuration notes
1. To run cucumber (ATDD,BDD framework) tests install SpecFlow visual studio extension per http://specflow.org/getting-started/#InstallSetup

2. NuGet packages installed
	- EntityFramework v6.1.3 
	- CsvHelper.2.16.3
	- SpecRun.SpecFlow.1.6.0

3. Csv files are mapped as embedded resources in DataContext\Seed\RiskContextSeedInit.cs
	- "Risk.DataContext.Seed.Settled.csv"
	- "Risk.DataContext.Seed.Unsettled.csv"

## Running the application
View controllers added to quickly meet UI requirements
- http://localhost:*nnn*/Customers
- http://localhost:*nnn*/Bets

WebApi controllers exist for reference
- http://localhost:*nnn*/api/customersapi
- http://localhost:*nnn*/api/Betsapi		

