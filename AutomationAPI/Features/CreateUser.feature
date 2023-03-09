Feature: Create User

@Regression
Scenario: Post operation for CreateUser1
	Given User Create "POST" request with payload
		| Key  | Value  |
		| Name | Jacob  |
		| Job  | Driver |
	When User Execute the request
	Then Verify Whether the "<Name>" And "<Job>" Is Same
	And Verify whether the status code "<StatusCode>"

Examples:
	| Name  | Job    | StatusCode |
	| Jacob | Driver | 201        |
