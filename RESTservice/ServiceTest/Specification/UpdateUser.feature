Feature: Update user

Scenario: Check update existing user
	Given Add test user to DB
	And "PUT" by /Services/TestService/Users/{NickName} request for upadating user
	When Request is executed
	Then Check response message when user updated
	And Check that user updated in DB
	And Delete test user

Scenario: Check update non existing user
	Given Add test user to DB
	And "PUT" by /Services/TestService/Users/{NickName} request for upadating non existing user
	When Request is executed
	Then Check response message when non existing user updated
	Then Delete test user
