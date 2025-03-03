using OpenQA.Selenium;
using Scrap.Services.Abstractions;

namespace Scrap.Services.PageScrapers
{
    internal class AInUlScraper : BasePageScraper, IPageScraper
    {
        public IList<Tuple<string, string>> Scrap(IWebDriver webDriver)
        {
            var ulElements = webDriver.FindElements(By.TagName("ul"));
            return base.Scrap(ulElements);
        }
    }
}
