using OpenQA.Selenium;
using Scrap.Repositories.Abstractions;
using Scrap.Services.Abstractions;

namespace Scrap.Services
{
    internal class ScraperService : IScraperService
    {
        private readonly IWebsiteRepository _websiteRepository;
        private readonly IWebDriver _webDriver;

        public ScraperService(IWebsiteRepository websiteRepository, IWebDriver webDriver)
        {
            _websiteRepository = websiteRepository;
            _webDriver = webDriver;
        }

        public void ScrapeAll()
        {
            IEnumerable<string> urls = _websiteRepository.GetAllWebsites().Select(x => x.Link);

            foreach (var url in urls)
            {
                Console.WriteLine($"Scraping tables from: {url}");
                var links = ReadHtml(url);
                foreach (var link in links)
                {
                    Console.WriteLine($"{link.Key} {link.Value}");
                }
            }
        }

        private Dictionary<string, string> ReadHtml(string url)
        {
            var links = new Dictionary<string, string>();
            try
            {
                _webDriver.Navigate().GoToUrl(url);
                Thread.Sleep(5000);

                var ulElements = _webDriver.FindElements(By.TagName("ul"));
                foreach (var ulElement in ulElements)
                {
                    var aElements = ulElement.FindElements(By.TagName("a"));
                    foreach (var aElement in aElements)
                    {
                        string text = aElement.Text;
                        string href = aElement.GetAttribute("href");
                        links.Add(text, href);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error scraping {url}: {ex.Message}");
            }
            return links;
        }
    }
}
