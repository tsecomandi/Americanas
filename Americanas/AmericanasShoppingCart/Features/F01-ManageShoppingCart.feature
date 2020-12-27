Feature: F01 Manage Shopping Cart

Scenario: T01 - Add item to shopping cart
	Given that I am in Americanas home page
	When I search for a product using the word "Samsung"
	Then a screen containing the search results is displayed
	When I click on the first product from the result list
	Then a screen containing the product details is displayed
	When I click on the button labeled comprar on product detail screen
	Then I should see a screen containing information about extended warranty is displayed
	When I click on continuar button on extended warranty screen
	Then I should see my shopping cart with the item listed in it

Scenario: T02 - Remove item from shopping cart
	Given that I am in Americanas home page
	When I search for a product using the word "Galaxy"
	Then a screen containing the search results is displayed
	When I click on the first product from the result list
	Then a screen containing the product details is displayed
	When I click on the button labeled comprar on product detail screen
	Then I should see a screen containing information about extended warranty is displayed
	When I click on continuar button on extended warranty screen
	Then I should see my shopping cart with the item listed in it
	When I click on the button labeled remover on the desired item
	Then I should see an empty shopping cart