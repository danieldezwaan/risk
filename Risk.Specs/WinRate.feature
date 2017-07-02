Feature: WinRate
	A customer has a win percentage that equals the percentage of the customers settled bets that the customer won

@requirement
Scenario: Average settled bet win percentage
	Given The data seed process is complete
	Then Customer 1 win percentage value should equal 0.7
