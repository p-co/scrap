using Scrap.Model;
using Scrap.Services.Abstractions.Mappers;

namespace Scrap.Services.Mappers
{
    internal class CollectedInfoMapper : ICollectedInfoMapper
    {
        public CollectedInfo ToDao(KeyValuePair<string, string> infos, Website website)
        {
            return new CollectedInfo()
            {
                Name = infos.Key,
                Link = infos.Value,
                ScrapedAt = DateTime.Now,
                WebsiteId = website.Id
            };
        }
    }
}
