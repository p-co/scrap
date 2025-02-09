using Newtonsoft.Json;
using Scrap.Model;
using Scrap.Repositories.Abstractions;

namespace Scrap.Repositories
{
    internal class CollectedInfoRepository : ICollectedInfoRepository
    {
        public void SaveCollectedInfo(CollectedInfo collectedInfo)
        {
            var existing = JsonConvert.DeserializeObject<IEnumerable<CollectedInfo>>(File.ReadAllText("collected-infos.json"));
            if (existing != null)
            {
                existing = existing.Append(collectedInfo);
                File.WriteAllText("collected-infos.json", JsonConvert.SerializeObject(existing));
            }
        }
    }
}
