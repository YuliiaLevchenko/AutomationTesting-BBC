Feature: Ability to use search box
	As a user I want to use search box so that I can see news that are relative to my request

@mytag
Scenario: User inputs main news category in the search box
	When User navigates to BBC News Page
	And User considers main News category as input for search box
	And User searches for input through search box
	Then the first article name equals main News category name
