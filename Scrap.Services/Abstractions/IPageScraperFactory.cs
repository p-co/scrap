namespace Scrap.Services.Abstractions
{
    public interface IPageScraperFactory
    {
        IPageScraper CreateScraper(string htmlDisposition);
    }
}
