using Newtonsoft.Json;
using Scrap.Model;
using Scrap.Repositories.Abstractions;

namespace Scrap.Repositories
{
    internal class WebsiteRepository : IWebsiteRepository
    {
        public IEnumerable<Website> GetAllWebsites()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Website>>(File.ReadAllText("websites.json"));
        }
    }
}
