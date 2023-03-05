Feature: SingleUser
@Test
Scenario: Get operation for SingleUser
	Given User Create "GET" request for "<User>" with "<Parameter>"  and its "<Value>"
	When User Execute the request
	And Verify whether the Name is "<Name>"
	Then Verify whether the status code "<StatusCode>"
	
Examples:
	| User   | StatusCode | Parameter | Value | Name         |
	| Single | 200        | Id        | 2     | Janet Weaver |

@Test
Scenario: Get operation for Ivalid SingleUser -Negative
	Given User Create "GET" request for "<User>" with "<Parameter>"  and its "<Value>"
	When User Execute the request
	Then Verify whether the status code "<StatusCode>"

Examples:
	| User   | StatusCode | Parameter | Value |
	| Single | 404        | Id        | 27    |
