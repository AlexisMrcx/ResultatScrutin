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