Feature: News Title should be correct
	As a user I want to see correct News Titles on the News Page in main and secondary sections


@MainTitle
Scenario: User explores the main News title
	When User navigates to BBC News Page
	Then The main News title is "Tenerife hotel locked down over coronavirus"
	
                                                                                                                                

@SecondaruTitles
Scenario: User explores the secondary News titles
	Given The list of correct titles for <News1>, <News2>, <News3>, <News4>
	When User navigates to BBC News Page
	Then Secondary News titles display correct
Examples:
|   News1                                          | News2								             | News3                            |News4                                   |
|   Former Egyptian President Hosni Mubarak dies   |German police raise toll of carnival car attack  | Inside Delhi's night of horror   |Plácido Domingo apologises to accusers  |     