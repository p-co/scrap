using Scrap.Model;

namespace Scrap.Services.Abstractions.Mappers
{
    internal interface ICollectedInfoMapper
    {
        public CollectedInfo ToDao(Tuple<string, string> infos, Website website);
    }
}
