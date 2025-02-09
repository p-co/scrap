using Scrap.Model;

namespace Scrap.Repositories.Abstractions
{
    public interface IWebsiteRepository
    {
        IEnumerable<Website> GetAllWebsites();
    }
}
