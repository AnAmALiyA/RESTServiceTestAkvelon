Feature: Delete user

@successful
Scenario: Check delete existing user
	Given Add test user to DB
	And "DELETE" by /Services/TestService/Users/{NickName} request
	When Request is executed
	Then Check response message when user deleted
	And Сheck that test user not stored in DB

@unsuccessful
Scenario: Check delete non existing user
	Given Add test user to DB
	And "DELETE" by /Services/TestService/Users/{NickName} request for non exsiting user
	When Request is executed
	Then Check response message when non existing user deleted
	Then Delete test user

