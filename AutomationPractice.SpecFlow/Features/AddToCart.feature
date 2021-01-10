Feature: AddToCart
	In order to buy some products
	As a client
	I want to add them to my cart

@addToCartFromGridAndList
Scenario: AddToCartFromGridAndList
	Given I'm on the 'Women' 'Tops' category in 'Grid' view
	When I add to cart the '1st' product
	Then I should see the confirmation for '1' product
	Given I'm on the 'Women' 'Dresses' category in 'List' view
	When I add to cart the '2nd' product
	Then I should see the confirmation for '2' products

@addToCartFromProductPageAndRemove
Scenario: AddToCartFromProductPageAndRemove
	Given I add to my cart '2' random products from 'Women' menu
	Then I should see the correct data in my cart
	When I remove the '2nd' product from the cart
	Then I should see the correct data in my cart
