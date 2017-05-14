Feature: Add user

@successful
Scenario: Add user
	Given "POST" request for "/Services/TestService/Users" endpoint with body message
	When Request is executed
	Then Сheck that user stored in DB
	And Check response message

@unsuccessful
Scenario: Add user with wrong data
	Given "POST" request for "/Services/TestService/Users" endpoint with wrong body message
	When Request is executed
	Then Сheck that user not stored in DB
	And Check wrong response message
