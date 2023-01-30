Feature: Register User

@regression
Scenario Outline: New User Registeration
Given User is on Registeration page
When User enters <username> and <password>
And User enters confirm <password>
And User clicks on RegisterButton
Then User navigates to Login Page
Examples: 

| username | password |
| testuser_1 | Test@123 |