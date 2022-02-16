Feature: Login

@UI_Test
Scenario: Success login of valid user 
	Given BuggyCars home page is loaded
	When user inputs creditials
	| Username | Password |
	| !!        | Test123! |
	Then click on Login button
	And user "Krish" is successfully logged in 

@UI_Test
Scenario: Login of invalid user 
	Given BuggyCars home page is loaded
	When user inputs creditials
	| Username | Password |
	| invalid  | Test123! |
	Then click on Login button
	And "Invalid username/password" message is displayed 

