Feature: This test suite contains test scenarios for Skill Page


Scenario: A. Verify user is able to Create a new Skill record with alpha code
	Given user logs into Mars portal and navigates to homepage
	When user creates new Skill record 'Writing'
	Then skill should be saved 'Writing'

Scenario Outline: B. Verify user is able to Edit an existing Skill record
	Given user logs into Mars portal and navigates to homepage
	When user edits an existing Skill record <oldSkill> <newSkill>
	Then skill should be updated <newSkill>

	Examples:
	| oldSkill | newSkill |
	| 'Writing'| 'Reading'|
	

Scenario: C. Verify user is able to Delete an existing Skill record
	Given user logs into Mars portal and navigates to homepage
	When user deletes an existing Skill record
	Then skill should be deleted

Scenario: E. Verify user is able to Delete all existing Skill records
	Given user logs into Mars portal and navigates to homepage
	When user deletes al existing Skill records
	Then skills should be deleted


Scenario Outline: D. Verify user is able to Create multiple Skills record
	Given user logs into Mars portal and navigates to homepage
	When user creates multiple Skill records 
	
	| skill     |
	| writing   |
	| Reading   |
	| Listening |
	| Skill@    |
	Then skill should be saved 

	| skill     |
	| Writing   |
	| Reading   |
	| Listening |
	| Skill1@   |