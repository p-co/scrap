using OpenQA.Selenium;
using Scrap.Services.Abstractions;

namespace Scrap.Services.PageScrapers
{
    internal class AInTableScraper : BasePageScraper, IPageScraper
    {
        public IList<Tuple<string, string>> Scrap(IWebDriver webDriver)
        {
            var tdElements = webDriver.FindElements(By.TagName("td"));
            return base.Scrap(tdElements);
        }
    }
}
