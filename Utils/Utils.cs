using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace AutomationPurchasesClothes.Utils
{
    public class Utils
    {
        private readonly IPage _page;
        public Utils(IPage page)
        {
            _page = page;
        }
        public async Task<bool> ExistLocator(string LocatorText)
        {
            bool Status;
            try
            {
                Status = await _page.IsVisibleAsync(LocatorText);
            }
            catch (Exception)
            {
                Status = false;
            }

            return Status;
        }
        public async Task ScreenShot(string route)
        {
            await _page.ScreenshotAsync(new PageScreenshotOptions { Path = route });
        }
    }
    
}
