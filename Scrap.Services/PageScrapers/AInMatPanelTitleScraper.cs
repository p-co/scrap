using OpenQA.Selenium;
using Scrap.Services.Abstractions;

namespace Scrap.Services.PageScrapers
{
    internal class AInMatPanelTitleScraper : IPageScraper
    {
        public IList<Tuple<string, string>> Scrap(IWebDriver webDriver)
        {
            var links = new List<Tuple<string, string>>();

            var matPanelElements = webDriver.FindElements(By.TagName("mat-panel-title"));
            foreach (var matPanelElement in matPanelElements)
            {
                var aElements = matPanelElement.FindElements(By.TagName("a"));
                foreach (var aElement in aElements)
                {
                    string text = aElement.FindElement(By.TagName("span")).Text;
                    string href = aElement.GetAttribute("href");
                    links.Add(Tuple.Create(text, href));
                }
            }
            return links;
        }
    }
}
