using OpenQA.Selenium;
using Scrap.Services.Abstractions;

namespace Scrap.Services.PageScrapers
{
    internal class AInMatPanelTitleScraper : BasePageScraper, IPageScraper
    {
        public IList<Tuple<string, string>> Scrap(IWebDriver webDriver)
        {
            var matPanelElements = webDriver.FindElements(By.TagName("mat-panel-title"));
            return base.Scrap(matPanelElements);
        }
    }
}
