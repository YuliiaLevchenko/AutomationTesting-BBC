Feature: Submitting the question form
	As a user I want to fill and submit my question to BBC

@FillingForm
Scenario: User fills in the form missing one input
	Given User generates text for all input fields but <Field>
	When User navigates to BBC Question Page
	And User fills in question form without <Field>
	And User clicks on Submit button
	Then Validation errors under empty fields display
Examples:
	| Field			|
	| Name          |
	| Email address |

@FillingTextArea
Scenario: User fills in textarea with length 141 symbols
	Given User generates text for textarea with length of 141 symbols
	When User navigates to BBC Question Page
	And User fills textarea with generated text
	Then An indicator of number of letters under the textarea displays '140/140'