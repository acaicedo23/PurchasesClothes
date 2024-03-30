using Microsoft.Playwright;
using System;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutomationPurchasesClothes.PageObjects
{
    public class PurchasesClothesPageObject : BasePageObject
    {
        public override string PagePath => "https://automationexercise.com/";
        private static readonly string ProductsMenuLocator = "//a[@href='/products']";
        private static readonly string ListProductLocator = "//div[@class='features_items']/div[@class='col-sm-4']";
        private static readonly string ShoppinCartLocator = "//a[@href='/view_cart']";

        private static readonly string ListCartItemLocator = "//div[@id='cart_info']/table[@id='cart_info_table']//tr";
        private static readonly string ListCartItemEmptyLocator = "//span[@id='empty_cart']/p";

        public override IPage Page { get ; set ; }

        public override IBrowser Browser { get; }
        
        public PurchasesClothesPageObject(IBrowser browser)
        {
            Browser = browser;
        }

        public async Task ClickOnProductMenu()
        {
            await Page.ClickAsync(ProductsMenuLocator);
        }
        public async Task SelectItemNumber(int ItemNumber)
        {
            string Answer = "";
            var Counter = 0;
            bool LoadPage = false;
            var PageUtils = new Utils.Utils(Page);
            while (LoadPage.Equals(false) && Counter <= 30)
            {
                await Page.WaitForTimeoutAsync(1000);
                Counter++;
                if (await PageUtils.ExistLocator(ListProductLocator))
                {

                    ILocator ListFile = Page.Locator(ListProductLocator);
                    int ProductItemNumber= await ListFile.CountAsync();
                    if (ProductItemNumber >= ItemNumber)
                    {
                        for (int i = 1; i <= ItemNumber; i++)
                        {
                            //Console.WriteLine(i);
                            string AddToCartLocator = "//a[@data-product-id='" + i + "'and text()='Add to cart']";
                            //string NameProductLocator = "//div[@class='productinfo text-center']/p >> nth(" + i + ")";


                            //Console.WriteLine("Sugerencia1 esta en la posicion[" + i + "]: " + await Page.InnerTextAsync(NameProductLocator));
                            await Page.ClickAsync(AddToCartLocator);
                            //Answer = Answer + await Page.InnerTextAsync(NameProductLocator) + ";";
                        }
                    }
                    else {
                        Answer = "The list is minus that 10";
                    }
                    LoadPage = true;
                    break;
                }
            }
            Console.WriteLine("Add Cart: " + Answer);
        }
        public async Task GoToShoppinCart()
        {
            await Page.ClickAsync(ShoppinCartLocator);
        }

        public async Task<int>TotalNumberItems()
        {
            int Answer=0;
            var Counter = 0;
            bool LoadPage = false;
            var PageUtils = new Utils.Utils(Page);
            while (LoadPage.Equals(false) && Counter <= 30)
            {
                await Page.WaitForTimeoutAsync(1000);
                Counter++;
                if (await PageUtils.ExistLocator(ListCartItemLocator))
                {
                    ILocator ListFile = Page.Locator(ListCartItemLocator);
                    Answer = await ListFile.CountAsync() - 1;
                    LoadPage = true;
                    break;
                }
            }
            Console.WriteLine("Number item on the Cart: " + Answer.ToString());
            
            return Answer;
        }

        public async Task DeleteEachDomainsOneByOne()
        { 
            var Counter = 0;
            bool LoadPage = false;
            var PageUtils = new Utils.Utils(Page);
            while (LoadPage.Equals(false) && Counter <= 30)
            {
                await Page.WaitForTimeoutAsync(1000);
                Counter++;
                if (await PageUtils.ExistLocator(ListCartItemLocator))
                {
                    ILocator ListFile = Page.Locator(ListCartItemLocator);
                    int ProductItemCartNumber = await ListFile.CountAsync();
                    for (int i = 1; i <= ProductItemCartNumber; i++)
                    {
                        //Console.WriteLine(i);
                        string DeleteToCartLocator = "//div[@id='cart_info']/table[@id='cart_info_table']//tr[" + i + "]/td[6]/a";
                        await Page.ClickAsync(DeleteToCartLocator);
                    }
                        LoadPage = true;
                    break;
                }
            }

            Console.WriteLine("Delete all domain ... " );
        }
        public async Task<string> ValidateShoppinCartIsEnty()
        {
            string Answer = "";
            var Counter = 0;
            bool LoadPage = false;
            var PageUtils = new Utils.Utils(Page);
            while (LoadPage.Equals(false) && Counter <= 30)
            {
                await Page.WaitForTimeoutAsync(1000);
                Counter++;
                if (await PageUtils.ExistLocator(ListCartItemEmptyLocator))
                {
                    Answer = "";
                }
                else { Answer = "Is not empty"; }
                LoadPage = true;
                break;
            }

            Console.WriteLine("Shoppin Cart domain "+Answer);

            return Answer;
        }
        
    }
}
