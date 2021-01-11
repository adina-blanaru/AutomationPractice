Feature: PlaceOrder
	In order to buy some clothes
	As a client
	I want to place an order

@placeOrderAsGuest
Scenario: PlaceOrderAsGuest
	Given I add to my cart '1' random product from 'Women' menu
	When I proceed to checkout from the Summary step
	Then I should see the 'Authentication' page
	When I sign in as 'Adina'
	Then I should see the correct data in my cart

@placeOrderAsUser
Scenario: PlaceOrderAsUser
	Given I'm logged in as 'Adina_new'
	When I add to my cart '2' random products from 'Women' menu
	And I place the order
	Then I should see the new order with the correct data