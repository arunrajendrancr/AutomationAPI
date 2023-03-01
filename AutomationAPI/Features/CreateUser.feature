Feature: Create User

Scenario: Post operation for CreateUser 
	Given User send Post request with "<Resource>" with "<Name>" And "<Job>"
	Then Verify whether the status code is "<StatusCode>"
	Then Verify Whether the "<Name>" And "<Job>" Is Same
	Examples:
	| Resource   | StatusCode | Name | Job     |
	| /api/users | 201        | Githin  | Engineer |
