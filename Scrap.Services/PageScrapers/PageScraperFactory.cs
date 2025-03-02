using Scrap.Services.Abstractions;

namespace Scrap.Services.PageScrapers
{
    internal class PageScraperFactory : IPageScraperFactory
    {
        public IPageScraper CreateScraper(string htmlDisposition)
        {
            return htmlDisposition switch
            {
                "a in mat-panel-title" => new AInMatPanelTitleScraper(),
                "" => new AInUlScraper(),
                _ => new AInUlScraper(),
            };
        }
    }
}
