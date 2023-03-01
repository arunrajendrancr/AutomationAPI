Feature: SingleUser

Scenario: Get operation for SingleUser 
	Given User send GET request with "<Resource>"
	Then Verify whether the status code "<StatusCode>"
	Then Verify whether the Name is "<Name>"

	Examples:
	| Resource    | StatusCode | Name         |
	| api/users/2 | 200        | Janet Weaver |
	| api/users/2 | 200        | Janet Weav   | //to fail
	

	Scenario: Get operation for Ivalid SingleUser -Negative
	Given User send GET request with "<Resource>"
	Then Verify whether the status code "<StatusCode>"

	Examples: 
	| Resource    | StatusCode | 
	| api/users/27 | 404       | 

