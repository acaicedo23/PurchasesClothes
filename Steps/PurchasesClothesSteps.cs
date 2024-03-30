using AutomationPurchasesClothes.PageObjects;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace PurchasesClothes.Steps
{
    [Binding]
    public class PurchasesClothesSteps
    {
        private readonly PurchasesClothesPageObject _pageObject;

        public PurchasesClothesSteps(PurchasesClothesPageObject pageObject)
        {
            _pageObject = pageObject;
        }

        [Given(@"User go to the URL page")]
        public async Task GivenUserGoToTheUrlPageIsAsync()
        {
            await _pageObject.NavigateAsync();
        }

        [Given(@"Add (.*) unique items to shopping cart")]
        public async Task GivenAddUniqueItemsToShoppingCart(int ItemNumber)
        {
            await _pageObject.ClickOnProductMenu();
            await _pageObject.SelectItemNumber(ItemNumber);
            
        }

        [When(@"Navigate to shopping cart")]
        public async Task WhenNavigateToShoppingCart()
        {
            await _pageObject.GoToShoppinCart();
        }

        [Then(@"verify total number of items (.*)")]
        public async Task ThenVerifyTotalNumberOfItems(int ItemNumber)
        {
            int ObtainedResult = await _pageObject.TotalNumberItems();
            Assert.IsTrue(ObtainedResult.ToString().ToLower().Equals(ItemNumber.ToString().ToLower()));
        }

        [Then(@"Remove all items one by one")]
        public async Task ThenRemoveAllItemsOneByOne()
        {
            await _pageObject.DeleteEachDomainsOneByOne();
        }

        [Then(@"Verify cart is empty")]
        public async Task ThenVerifyCartIsEmpty()
        {
            string ObtainedResult = await _pageObject.ValidateShoppinCartIsEnty();
            Assert.IsEmpty(ObtainedResult); 
            
        }

        [Then(@"Close browser")]
        public async Task ThenCloseBrowser()
        {
           // await _pageObject.quit
        }


    }
}
