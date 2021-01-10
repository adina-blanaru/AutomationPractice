Feature: CompareProducts
	In order to decide what to buy
	As a client
	I want to be able to compare the products

@addRemoveProductToCompare
Scenario: AddRemoveProductToCompare
	Given I'm on the 'Women' '<Category>' category in '<View>' view
	Then I should be able to add to compare the '<Product>' product
	And I should be able to remove from compare the '<Product>' product
	Examples: 
	| Category | View | Product               |
	| Dresses  | Grid | Printed Chiffon Dress |
	| Tops     | List | Blouse                |

@compareProductsAndRemove
Scenario: CompareProductsAndRemove
	Given I'm on the 'Women' menu
	When I add to compare the first '3' products
	Then I should see the '3' products in the comparison page
	When I remove the first '2' products from the compare list
	Then I shouldn't see the '2' products in the comparison page