Feature: Scrutin

Scenario: vote is finish
	Given followings votes
		| name  |
		| David |
		| David |
		| Marc  |
		| Jeff  |
		| David |
		| Jeff  |
	When all peoples votes
	Then vote is closed

Scenario: candidate have more 50% of votes
	Given followings candidates
		| candidates |
		| David      |
		| Marc       |
		| Jeff       |
	Given followings votes
		| name  |
		| David |
		| David |
		| Marc  |
		| David |
		| Jeff  |
	When all peoples votes
	And counting is finish
	Then David won

Scenario: Show all votes and percent
	Given followings candidates
		| candidates |
		| David      |
		| Marc       |
	Given followings votes
		| name  |
		| David |
		| David |
		| David |
		| Marc  |
	When all peoples votes
	And counting is finish
	Then show David: 3;75%, Marc: 1;25%

Scenario: don't have majority
	Given followings candidates
		| candidates |
		| David      |
		| Marc       |
		| Jeff       |
	Given followings votes
		| name  |
		| David |
		| David |
		| David |
		| Marc  |
		| Marc  |
		| Jeff  |
	When all peoples votes
	And counting is finish
	Then second round with David and Marc

Scenario: who won on second round
	Given followings candidates
		| candidates |
		| David      |
		| Marc       |
	Given followings votes
		| name  |
		| David |
		| David |
		| David |
		| Marc  |
		| Marc  |
		| Marc  |
		| Marc  |
	Given is second round
	When all peoples votes
	And counting is finish
	Then Marc won

Scenario: egality on second round
	Given followings candidates
		| candidates |
		| David      |
		| Marc       |
	Given followings votes
		| name  |
		| David |
		| David |
		| Marc  |
		| Marc  |
	Given is second round
	When all peoples votes
	And counting is finish
	Then egality