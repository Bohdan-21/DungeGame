using Scripts.Data.SaveData;
using System.Collections.Generic;

namespace Scripts.Services.PlayerProgressService
{
    public interface IPlayerProgressService
    {
        PlayerProgress PlayerProgress { get; set; }
        List<IPlayerProgressUpdater> ProgressUpdaters { get; }

        void AddProgressUpdater(IPlayerProgressUpdater progressUpdater);
        void Cleanup();
    }
}