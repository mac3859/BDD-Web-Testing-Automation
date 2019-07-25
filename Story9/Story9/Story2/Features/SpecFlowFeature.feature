Feature: Login 
	In order to login successfully
	As a user
	I want to check valid and invalid login results

@Story1
Scenario: login with valid application
	Given I am in login page
	When I input the valid user application
	Then I can login and see avatar image

@Story1
Scenario: login with valid application, and Remember Me is selected
    Given I am in login page
	When I input the valid user application and select Remember Me
	Then I can login and see avatar image 

@Story1
Scenario: login with invalid application
    Given I am in login page
	When I input the invalid user application
	Then I cannot login and see error messages 
	
@Story2
Scenario: logout the current login page
    Given I am already in login page
	When I click logut button
	Then I can logout and see login screen

@Story3
Scenario: choose and upload a new avatar icon
    Given I am already in picture uploading page
	When I upload a new picture
	Then I can see a new avatar icon

@Story4
Scenario: verify register error message 
    Given I am already in register page
	When I input invalid register information
	Then I can see error message 

@Story5
Scenario Outline: verify reset password error message
    Given I am already in reset password page
	When I enter "<wrongEmails>"
	Then I can see "<errorMessage>" of resetting
	
	Examples: 
	| wrongEmails     | errorMessage           |
	| e               | 请输入有效的电子邮件地址 |
	| e@outlook.com   | 该邮箱地址没有注册过帐号 |

@Story6
Scenario: user can update the basic info
   Given I am already in basic info setting page
   When I update info and click save button
   Then I can see alert success message

@Story6
Scenario: validation should work
   Given I am already in basic info setting page
   When I entre error profile info
   Then the error message as below should be seen

@Story8
Scenario: do default search for course order
   Given I am already in course order page
   When I click search buttton
   Then I can see some orders

@Story8
Scenario: do default search for class order
   Given I am already in class order page
   When I click search button
   Then I can see some orders

@Story8
Scenario: do multiple search for course
   Given I am already in course order page
   When I search for course order through filters
   Then I can see actual result match expected result

@Story8
Scenario: do multiple search for class
   Given I am already in class order page
   When I search for class order through filters
   Then I can see actual result match expected result

@Story9
Scenario: do filter search on info management page
   Given I am already in info management page
   When I search item based on category,keyword,property and status
   Then I can see search result match expected result

@Story9
Scenario: change the status of an article
   Given I am already in info management page
   When I change the status of an article
   Then I can see updated status
   Then I do vice verse change the status of the article
   Then I can see updated status again

@Story9
Scenario: add a category on info management page
   Given I am in article category page
   When I add new category 
   Then I can see new added category on the UI

@Story9
Scenario: add a category and edit the name 
   Given I am in article category page
   When  I add new category
   And I edit the name of new category
   Then I can see new name of category on the UI






	


   



