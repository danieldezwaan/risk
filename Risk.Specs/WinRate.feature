Feature: WinRate
	A customer has a win percentage that equals the percentage of the customers settled bets that the customer won

@mytag
Scenario: Average settled bet win percentage
	Given The average win rate for a customer is greater than 0
	When The average win rate is calculated
	Then The customer win percentage value should equal the win rate
