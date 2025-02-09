using Scrap.Model;

namespace Scrap.Repositories.Abstractions
{
    public interface ICollectedInfoRepository
    {
        void SaveCollectedInfo(CollectedInfo collectedInfo);
    }
}
