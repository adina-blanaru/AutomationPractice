Feature: Authentication
	In order to access the website
	As a potential client
	I want to create an account and login

@createAccount
Scenario: CreateAccount
	Given I'm on the Authentication page
	When I create an account
	| Email           | Title | FirstName | LastName | Password  | DateOfBirth | Address    | City   | ZipCode | State  | Country       | MobilePhone | AddressAlias |
	| adtst0@test.com | Mrs.  | Ad        | Bl       | pass12345 | 11/10/1985  | My address | Brasov | 12345   | Alaska | United States | 6256416516  | Home         |
	Then I should see the 'My account' page


@validLogin
Scenario: ValidLogin
	Given I'm on the Authentication page
	When I login with credentials
	| Email          | Password  |
	| adtst@test.com | pass12345 |
	Then I should see the 'My account' page


@invalidLogin
Scenario Outline: InvalidLogin
	Given I'm on the Authentication page
	When I login with credentials
	| Email   | Password   |
	| <Email> | <Password> |
	Then I should see the '<ErrorMessage>' authentication error
	
	Examples: 
	| Email          | Password      | ErrorMessage               |
	| adtst@test.com | wrongPassword | Authentication failed.     |
	| adtst@test.com |               | Password is required.      |
	| invalidEmail   |               | Invalid email address.     |
	|                |               | An email address required. |