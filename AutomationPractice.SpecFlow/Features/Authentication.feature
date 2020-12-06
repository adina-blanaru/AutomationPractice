Feature: Authentication
	In order to buy products
	As a customer
	I want to be able to create an account

@createAccount
Scenario: CreateAccount
	Given I'm on the Authentication page
	When I create an account
	| Email           | Title | FirstName | LastName | Password  | DateOfBirth | Address    | City   | ZipCode | State  | Country       | MobilePhone | AddressAlias |
	| adtst0@test.com | Mrs.  | Ad        | Bl       | pass12345 | 11/10/2012  | my address | Brasov | 12345   | Alaska | United States | 6256416516  | Home         |
	Then I should see the 'My account' page

