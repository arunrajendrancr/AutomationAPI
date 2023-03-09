Feature: Update User
@Test
Scenario: Put operation for UpdateUser
	Given User Create "PUT" request with payload
		| Key  | Value  |
		| Name | San    |
		| Job  | Doctor |
		| Id   | 123    |
	When User Execute the request
	Then Verify Whether the "<Name>" And "<Job>" Is Updated
	And Verify whether the status code "<StatusCode>"
	
Examples:
	| StatusCode | Name | Job    |
	| 200        | San  | Doctor |

@Test
Scenario: Patch operation for UpdateUser
	Given User Create "PATCH" request with payload
		| Key  | Value   |
		| Name | Joly    |
		| Job  | Teacher |
		| Id   | 123     |
	When User Execute the request
	Then Verify Whether the "<Name>" And "<Job>" Is Updated
	And Verify whether the status code "<StatusCode>"
Examples:
	| StatusCode | Name | Job     |
	| 200        | Joly | Teacher |