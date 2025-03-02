using OpenQA.Selenium;
using Scrap.Services.Abstractions;

namespace Scrap.Services.PageScrapers
{
    internal class AInTableScraper : IPageScraper
    {
        public IList<Tuple<string, string>> Scrap(IWebDriver webDriver)
        {
            var links = new List<Tuple<string, string>>();

            var ulElements = webDriver.FindElements(By.TagName("td"));
            foreach (var ulElement in ulElements)
            {
                var aElements = ulElement.FindElements(By.TagName("a"));
                foreach (var aElement in aElements)
                {
                    string text = aElement.Text;
                    string href = aElement.GetAttribute("href");
                    links.Add(Tuple.Create(text, href));
                }
            }
            return links;
        }
    }
}
