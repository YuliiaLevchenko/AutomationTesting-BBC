Feature: Submitting the form with news to share
	As a user I want to send my suggested News to BBC

@FillingForm
Scenario: User fills in the News Share form missing one input
	Given User generates text for all input fields in News Share form but <Field>
	When User navigates to BBC Share News Page
	And User fills in share news form without <Field>
	And User clicks on Send button
	Then User stays on the same page
Examples:
	| Field			|
	| email         |
	| News			|
