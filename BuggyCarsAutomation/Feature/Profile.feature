Feature: Profile


@UI_Test
Scenario Outline: Profile page - Login and update password 
	Given BuggyCars home page is loaded
	When user inputs creditials
	| Username | Password |
	| @@@        | Test123! |
	Then click on Login button
	And user "!" is successfully logged in 
	When profile is clicked on
	Then the profile page is displayed 
	And input the info to change password
	| Password        | NewPassword | PasswordComfirmation |
	| Test123!        | Test12345#  | Test12345#           |
	When user clicks on "submit"
	Then success message is displayed
	And input the info to change password 
	| Password        | NewPassword | PasswordComfirmation | 
	| Test12345#      | Test123!    | Test123!             | 
	When user clicks on "submit"
	Then success message is displayed


@UI_Test
Scenario: Profile page - Login and update name  
	Given BuggyCars home page is loaded
	When user inputs creditials
	| Username | Password |
	| !!        | Test123! |
	Then click on Login button
	And user "Krish" is successfully logged in 
	When profile is clicked on
	Then the profile page is displayed 
	And user updates basic info 
	| Firstname | Lastname |
	| AutoTest  | Tester   |
	When user clicks on "submit"
	Then success message is displayed
	And user updates basic info 
	| Firstname | Lastname |
	| Krish     | !        |
	When user clicks on "submit"
	Then success message is displayed



