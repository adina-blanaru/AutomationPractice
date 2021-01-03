Feature: Wishlist
	In order to save the clothes I like
	As a client
	I want to add them to a whishlist

@addRemoveProductInWishlist
Scenario: AddRemoveProductInWishlist
	Given I'm logged into the site
	| Email          | Password  |
	| adtst@test.com | pass12345 |
		And I'm on the 'Women' '<Category>' category in '<View>' view
	When I add to wishlist the '<Product>' product
	Then I should see the '<Product>' product in my wishlist
	When I remove the '<Product>' product from the wishlist
	Then I shouldn't see the '<Product>' product in my wishlist
	Examples: 
	| Category | View | Product               |
	| Dresses  | Grid | Printed Chiffon Dress |
	| Tops     | List | Blouse                |