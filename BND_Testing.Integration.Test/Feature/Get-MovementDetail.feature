Feature: Read Moment detials

Background: 
	Given Set up data with details
		| Productype       | ExternalAccount | CustomerFirstName | CustomerLastName | CustomerEmail        |
		| SavingsRetirment | Account_Test    | Jane              | Doe              | Test@brandnewday.com |  
		
####################################################
# Functional API Validation
####################################################
Scenario: The user gets the data to display the movement overview and should receive details.
	When the user gets movement detial with by Product Type "SavingsRetirment" and fillterType "Free"
	Then the user gets a response with code "200" 
	And the user gets data details response with values
		| pageNumber | pageSize |
		| 10         | 10       |  
	And the user gets movment details response with values
		| account             | movementType | amount | accountFrom  | accountTo   |
		| Brandnewday_Account | Free         | 1000   | Jane_Account | Joe_Account |  

Scenario: The user gets the data to display the movements overview with no map and no movement type should respond successfully but with empty movements.
	When the user gets movement detial with by Product Type "SavingsRetirment" and fillterType "Tax"
	Then the user gets a response with code "200" 
	And the user gets data details response with values
		| pageNumber | pageSize |
	And the user gets movment details response with values
		| account             | movementType | amount | accountFrom  | accountTo   |

####################################################
# Functional API Invalidation
####################################################
Scenario: The user gets data to display with an invalid product type and should response an error
	When the user gets movement detial with by Product Type "Test" and fillterType "Free"
	Then the user gets a response with code "404"

Scenario: The user gets data to display the movements overview with an empty filler type and should response an error
	When the user gets movement detial with by Product Type "SavingsRetirment" and fillterType "Test"
	Then the user gets a response with code "404" 

	

