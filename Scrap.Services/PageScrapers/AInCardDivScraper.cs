using OpenQA.Selenium;
using Scrap.Services.Abstractions;

namespace Scrap.Services.PageScrapers
{
    internal class AInCardDivScraper : IPageScraper
    {
        public IList<Tuple<string, string>> Scrap(IWebDriver webDriver)
        {
            var links = new List<Tuple<string, string>>();

            var cardBodyElements = webDriver
                .FindElements(By.ClassName("offer-card-body"))
                .Select(x => x.FindElement(By.ClassName("offer-body--content")));
            foreach (var cardBodyElement in cardBodyElements)
            {
                var aElements = cardBodyElement.FindElements(By.TagName("a"));
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
