using Scrap.Model;
using Scrap.Services.Abstractions.Mappers;

namespace Scrap.Services.Mappers
{
    internal class CollectedInfoMapper : ICollectedInfoMapper
    {
        public CollectedInfo ToDao(Tuple<string, string> infos, Website website)
        {
            return new CollectedInfo()
            {
                Name = infos.Item1,
                Link = infos.Item2,
                ScrapedAt = DateTime.Now,
                WebsiteId = website.Id
            };
        }
    }
}
