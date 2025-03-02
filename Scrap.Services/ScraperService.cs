using OpenQA.Selenium;
using Scrap.Model;
using Scrap.Repositories.Abstractions;
using Scrap.Services.Abstractions;
using Scrap.Services.Abstractions.Mappers;

namespace Scrap.Services
{
    internal class ScraperService(IWebsiteRepository websiteRepository, ICollectedInfoRepository collectedInfoRepository, ICollectedInfoMapper collectedInfoMapper, IPageScraperFactory factory, IWebDriver webDriver) : IScraperService
    {
        private readonly IWebsiteRepository _websiteRepository = websiteRepository;
        private readonly ICollectedInfoRepository _collectedInfoRepository = collectedInfoRepository;
        private readonly ICollectedInfoMapper _collectedInfoMapper = collectedInfoMapper;
        private readonly IPageScraperFactory _factory = factory;
        private readonly IWebDriver _webDriver = webDriver;

        public void ScrapeAll()
        {
            IEnumerable<Website> websites = _websiteRepository.GetAllWebsites();

            foreach (var website in websites)
            {
                Console.WriteLine($"Scraping tables from: {website.Name}");
                var links = ReadHtml(website);
                foreach (var link in links)
                {
                    _collectedInfoRepository.SaveCollectedInfo(_collectedInfoMapper.ToDao(link, website));
                    Console.WriteLine($"{link.Item1} {link.Item2}");
                }
            }
        }

        private IList<Tuple<string, string>> ReadHtml(Website website)
        {
            IList<Tuple<string, string>> links = [];
            try
            {
                _webDriver.Navigate().GoToUrl(website.Link);
                Thread.Sleep(5000);

                IPageScraper scraper = _factory.CreateScraper(website.HtmlDisposition);
                links = scraper.Scrap(_webDriver);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error scraping {website.Link}: {ex.Message}");
            }
            return links;
        }
    }
}
