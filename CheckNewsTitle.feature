Feature: NewsTitlesCheck
	As a user I want to see correct titles for main and secondary News Header

Background: 
	Given User generates correct header title
	And User visits BBC Home Page
	And User navigates to News Page

@MainNews
Scenario: Check the main news title correctness
	When User checks the main header title
	Then the main news title should be should be 'China releases largest study on Covid-19 outbreak'

@SecondaryNews
Scenario: Check the secondary news titles correctness
	When User checks the secondary header titles
	Then the secondary news title should be should be 'dictionary'