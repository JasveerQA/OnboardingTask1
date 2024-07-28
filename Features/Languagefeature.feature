Feature: This test suite contains test scenarios for Language Page


Scenario: A. Verify user is able to Create a new Language record
	Given I log into Mars portal and navigates to Homepage
	When I create a new Language record 'English'
	Then the language should be saved successfully 'English'

Scenario Outline: B. Verify user is able to Edit an existing Language record
	Given I log into Mars portal and navigates to Homepage
	When I edit an existing Language record <newlanguage>
	Then the language should be updated <newlanguage>

	Examples:
	| newlanguage |
	| 'Hindi'|


Scenario: C. Verify user is able to Delete an existing Language record
	Given I log into Mars portal and navigates to Homepage
	When I delete an existing Language record 
	Then the language should be deleted

Scenario Outline: D. Verify user is able to Create multiple Language records
	Given user logs into Mars portal and navigates to homepage
	When user creates multiple Language records 
	
	| language  |
	| English   |
	| Hindi   |
	| Punjabi |
	| Language2 |
	Then Language should be saved
	
	| language  |
	| English   |
	| Hindi   |
	| Punjabi |
	| Language2 |

	