Feature: Create User

@Regression
Scenario: Post operation for CreateUser1
	Given User Create "POST" request with payload
		| Key  | Value  |
		| Name | Jacob  |
		| Job  | Driver |
	When User Execute the request
	And Verify Whether the "<Name>" And "<Job>" Is Same
	Then Verify whether the status code "<StatusCode>"

Examples:
	| Name  | Job    | StatusCode |
	| Jacob | Driver | 201        |
