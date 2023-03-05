Feature: ListUser
@Regression
Scenario: Get operation for ListUser
	Given User Create "GET" request for "<User>" with "<Parameter>"  and its "<Value>"
	When User Execute the request
	Then Verify whether the status code "<StatusCode>"

Examples:
	| User | StatusCode | Parameter  | Value |
	| All  | 200        | PageNumber | 2     |

@Test
Scenario: Verify whether a perticular user exist in User's list
	Given User Create "GET" request for "<User>" with "<Parameter>"  and its "<Value>"
	When User Execute the request
	Then Verify whether the "<UserName>" exist in User's list
	Then Verify whether the status code "<StatusCode>"

Examples:
	| User | StatusCode | Parameter  | Value | UserName         |
	| All  | 200        | PageNumber | 2     | Lindsay Ferguson |

	

