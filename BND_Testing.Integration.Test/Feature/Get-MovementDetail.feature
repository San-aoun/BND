﻿Feature: Read Moment detials

Background: 
	Given Set up data with details
		| Productype       | ExternalAccount | CustomerFirstName | CustomerLastName | CustomerEmail        |
		| SavingsRetirment | Account_Test    | Jane              | Doe              | Test@brandnewday.com |  
		
####################################################
# Functional API Validation
####################################################
Scenario: user gets the data to display the movements overview should get detials
	When user gets movement detial with by Product Type "SavingsRetirment"
	Then the user gets a response with code "200" 
	And the user gets data details response with values
		| pageNumber | pageSize |
		| 10         | 10       |  
	And the user gets movment details response with values
		| account             | movementType | amount | accountFrom  | accountTo   |
		| Brandnewday_Account | Free         | 1000   | Jane_Account | Joe_Account |  

####################################################
# Functional API Invalidation
####################################################
Scenario: user gets the data to display with invalid product indentifier should return an error
	When user gets movement detial with by Product Type "Test"
	Then the user gets a response with code "400"
	

