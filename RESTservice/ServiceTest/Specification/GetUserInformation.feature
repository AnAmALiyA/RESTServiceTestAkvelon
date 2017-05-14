Feature: Get user information

@successful
Scenario: Check get existing user information
	Given Add test user to DB
	And "GET" by /Services/TestService/Users/{NickName} request for user info endpoint
	When Request is executed
	Then Check response message for get user info endpoint
	And Сheck that test user stored in DB
	And Delete test user

@unsuccessful
Scenario: Check get non existing user information
	Given "GET" by /Services/TestService/Users/{NickName} request for non exist user info endpoint
	When Request is executed
	Then Check response message for non existing user
	And Сheck that test user not stored in DB
	And Delete test user
