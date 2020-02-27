Feature: Sports Matches Result
	As a User I want to check sport matches results in sport catregory

@Sport
Scenario: User navigates to Scottish Premiership, select match and checks the score on the displayed page
	When User navigates to Sport Category
	And User navigates to Scottish Premier League matches links
	And User clicks on the matches link in series
	Then Score on the opened page equals score on the page with matches links
