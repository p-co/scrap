using Scrap.Services.Abstractions;

namespace Scrap.Services.PageScrapers
{
    internal class PageScraperFactory : IPageScraperFactory
    {
        public IPageScraper CreateScraper(string htmlDisposition)
        {
            return htmlDisposition switch
            {
                "a in card div" => new AInCardDivScraper(),
                "a in mat-panel-title" => new AInMatPanelTitleScraper(),
                "a in table" => new AInTableScraper(),
                "a in offer class" => new AInOfferClassScraper(),
                "" => new AInUlScraper(),
                _ => new AInUlScraper(),
            };
        }
    }
}
