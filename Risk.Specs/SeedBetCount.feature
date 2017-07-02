Feature: SeedBetCount
	Check that all bets have been migrated from seed data

@mytag
Scenario: Compare number of bets imported
	Given Bets have been imported from csv
	Then the count should be 72
