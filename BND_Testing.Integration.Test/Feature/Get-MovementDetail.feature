Feature: Read Moment detials

Background: 
	Given Set up data with details
		| ProductId | Productype   | ExternalAccount | CustomerFirstName | CustomerLastName | CustomerEmail        |
		| 001       | Product_Test | Account_Test    | Joe               | Doe              | Test@brandnewday.com |
		
####################################################
# Functional API Validation
####################################################
Scenario: user gets the data to display the movements overview should get detials
	When user gets movement detial with by product id "001"
	Then the user gets a response with code "200" 
	And the user gets data details response with values
		| pageNumber | pageSize |
		| 10         | 10       |  
	And the user gets movment details response with values
		| account              | movementType | amount | accountFrom  | accountTo    |
		| Test@brandnewday.com | Free         | 1000   | Jane_Account | Jone_Account |  

####################################################
# Functional API Validation
####################################################
Scenario: user gets the data to display with invalid product indentifier should return an error
	When user gets movement detial with by product id "<Product Id>"
	Then the user gets a response with code "400" 

	Examples: 
	| Product Id |
	| Test       |
	|            |
