Feature: Registration

@UI_Test
Scenario: Successful user registration 
	Given BuggyCars registration page is loaded
	When the information is inputted in 
	|      Username       | Firstname   | Lastname        | Password              | PasswordComfirmation  |
	|   Westpacauto       | UI          | Automation	  | ThisIsAutomation12@   | ThisIsAutomation12@   |
	Then click on the Register button
	And registration is successful message is displayed 

	Scenario: Unsuccessful user registration 
	Given BuggyCars registration page is loaded
	When the information is inputted in 
	|      Username       | Firstname   | Lastname        | Password              | PasswordComfirmation  |
	|   Westpacauto    |     UI      |Automation	      | ThisIsAutomation      |  ThisIsAutomation     |
	Then click on the Register button
	And registration is unsuccessful message is displayed 


