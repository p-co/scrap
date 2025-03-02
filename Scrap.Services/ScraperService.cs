using OpenQA.Selenium;
using Scrap.Model;
using Scrap.Repositories.Abstractions;
using Scrap.Services.Abstractions;
using Scrap.Services.Abstractions.Mappers;

namespace Scrap.Services
{
    internal class ScraperService : IScraperService
    {
        private readonly IWebsiteRepository _websiteRepository;
        private readonly ICollectedInfoRepository _collectedInfoRepository;
        private readonly ICollectedInfoMapper _collectedInfoMapper;
        private readonly IWebDriver _webDriver;

        public ScraperService(IWebsiteRepository websiteRepository, ICollectedInfoRepository collectedInfoRepository, ICollectedInfoMapper collectedInfoMapper, IWebDriver webDriver)
        {
            _websiteRepository = websiteRepository;
            _collectedInfoRepository = collectedInfoRepository;
            _collectedInfoMapper = collectedInfoMapper;
            _webDriver = webDriver;
        }

        public void ScrapeAll()
        {
            IEnumerable<Website> websites = _websiteRepository.GetAllWebsites();

            foreach (var website in websites)
            {
                Console.WriteLine($"Scraping tables from: {website.Name}");
                var links = ReadHtml(website.Link);
                foreach (var link in links)
                {
                    _collectedInfoRepository.SaveCollectedInfo(_collectedInfoMapper.ToDao(link, website));
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
