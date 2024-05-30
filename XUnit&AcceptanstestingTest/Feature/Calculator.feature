Feature: Calculator

    Scenario: Addition
	When I enter 5
	And I enter 3
	And I press addition
	Then the result should be 8

	Scenario: Subtraction
	When I enter 51
	When I enter 22
	And I press subtract
	Then the result should be 29

	Scenario: Multiplication
	When I enter 2.5
	When I enter 1.5
	And I press multiply
	Then the result should be 3.75

	Scenario: Division
	When I enter 20
	When I enter 4
	And I press division
	Then the result should be 5