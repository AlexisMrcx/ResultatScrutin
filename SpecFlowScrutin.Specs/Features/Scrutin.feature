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