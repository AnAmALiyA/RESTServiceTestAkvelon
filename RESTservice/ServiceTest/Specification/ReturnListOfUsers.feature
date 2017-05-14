Feature: Return list of users

Scenario: Check response format for Get All Users endpoint
	Given Add test user to DB
	And "GET" request for "/Services/TestService/Users" endpoint
	When Request is executed
	Then Return list of users response is validated

Scenario: Check response when no users in DB
	Given Delete All users from DB
	And "GET" request for "/Services/TestService/Users" endpoint
	When Request is executed
	Then Response message validated
	And Delete test user
