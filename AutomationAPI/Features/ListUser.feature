Feature: ListUser

Scenario: Get operation for ListUser 
	Given User send GET request with "<Resource>"
	Then Verify whether the status code "<StatusCode>"

	Examples:
	| Resource         | StatusCode |
	| api/users?page=2 | 200        |

Scenario: Get operation for ListUser - Negative Case
	Given User send GET request with "<Resource>"
	Then Verify whether the status code "<StatusCode>"

	Examples:
	| Resource | StatusCode |
	| ap       | 404        |

	Scenario: Verify whether a perticular user exist in User's list
	Given User send GET request with "<Resource>"
	Then Verify whether the status code "<StatusCode>"
	Then Verify whether the "<User>" exist in User's list

	Examples:
	| Resource         | StatusCode | User             |
	| api/users?page=2 | 200        | Lindsay Ferguson |



