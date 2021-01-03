Feature: SearchProducts
	In order to easily find a product
	As a client
	I want to be able to search the products

@searchProducts
Scenario: SearchProducts
	Given I'm on the Home page
	When I search for '<SearchText>'
	Then I should see the 'Search' page
	And I should see expected results
	| SearchText   | ResultsCount   | ErrorMessage   |
	| <SearchText> | <ResultsCount> | <ErrorMessage> |

	Examples: 
	| SearchText         | ResultsCount | ErrorMessage                          |
	| summer dress       | 4            |                                       |
	| blouse             | 1            |                                       |
	| random search text | 0            | No results were found for your search |
