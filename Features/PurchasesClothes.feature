Feature: PurchasesClothes

Browse the website and add 10 unique items to shopping cart

Background:
Scenario Outline: Purchases Clothes
Given User go to the URL page
And Add <ItemNumber> unique items to shopping cart
When Navigate to shopping cart
Then verify total number of items <ItemNumber>
And Remove all items one by one
And Verify cart is empty
#And Close browser

	Examples: 
	| ItemNumber |
	| 7          |
