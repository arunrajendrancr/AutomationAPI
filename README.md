# AutomationAPI
Specflow Restsharp Framework

Uses:
SpecFlow
RestSharp
ExtentReports

Implemented User Secrets with sample Username and Password

Project structure

project related part with models and utility
--models/: classes that represent data models of the application under the test (POJO classes)
--utility/: helpers class with methods that performs REST operations GET,POST,PUT,PATCH

Specflow implementation of the tests
--features/: Gherkin feature files with test scenarios
--hooks/: Specflow hooks
--stepdefinitions/: step definition classes
--report/: extent reports are generated here after each execution

config.json: contains env and url details
extent-config.xml: contains configuration details of extent report

Tests execution
Right Click on Feature or individual Scenario-> Click Run

Reporting
Extent Report is used as a reporting tool. Report data will be placed in reports folder.

