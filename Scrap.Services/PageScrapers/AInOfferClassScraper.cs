using OpenQA.Selenium;
using Scrap.Services.Abstractions;

namespace Scrap.Services.PageScrapers
{
    internal class AInOfferClassScraper : BasePageScraper, IPageScraper
    {
        public IList<Tuple<string, string>> Scrap(IWebDriver webDriver)
        {
            
            var offerElements = webDriver.FindElements(By.ClassName("offerlist-item"));
            return base.Scrap(offerElements);
        }
    }
}
