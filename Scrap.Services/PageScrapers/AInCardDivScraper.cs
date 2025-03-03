using OpenQA.Selenium;
using Scrap.Services.Abstractions;

namespace Scrap.Services.PageScrapers
{
    internal class AInCardDivScraper : BasePageScraper, IPageScraper
    {
        public IList<Tuple<string, string>> Scrap(IWebDriver webDriver)
        {
            var cardBodyElements = webDriver
                .FindElements(By.ClassName("offer-card-body"))
                .Select(x => x.FindElement(By.ClassName("offer-body--content")));
            return base.Scrap(cardBodyElements);
        }
    }
}
