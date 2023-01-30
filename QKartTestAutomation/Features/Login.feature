Feature: Login Qkart 
As a EndUser I should be able to login into QKart application


Scenario: Login into app with valid credentials
	Given User is on Login Page
	When User enters
	| UserName   | Password |
	| testuser_1 | Test@123 |
	And User clicks on Login button
	Then User navigates to Home Page and UserName is displayed
	| UserName   |
	| testuser_1 |
