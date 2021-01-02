Feature: Navigation
	In order to see the available products
	As a user
	I want to be able to access all the categories

@topMenuNavigation
Scenario: TopMenuNavigation
	Given I'm on the Home page
	Then I should be able to access all the menus

@womenProductsNavigation
Scenario: WomenProductsNavigation
	Given I'm on the Home page
	Then I should be able to access the Women categories
	And I should be able to access the Women subcategories