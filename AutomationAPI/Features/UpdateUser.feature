Feature: Update User

Scenario: Put operation for UpdateUser 
	Given User send Put request with "<Resource>" with "<Name>" And "<Job>" to update
	Then Verify whether the status code is "<StatusCode>"
	Then Verify Whether the "<Name>" And "<Job>" Is Updated
	Examples:
	| Resource       | StatusCode | Name | Job    |
	| /api/users/123 | 200        | San  | Doctor |


Scenario: Patch operation for UpdateUser 
	Given User send Patch request with "<Resource>" and payload
	| Key  | Value |
	| Name | Don   |
	| Job  | nurse |
	Then Verify whether the status code is "<StatusCode>"
	Examples:
	| Resource       | StatusCode |
	| /api/users/711 | 200        |