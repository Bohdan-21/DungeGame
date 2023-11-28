using Scripts.SaveData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts.Services.PlayerProgressService
{
    class PlayerProgressService : IPlayerProgressService
    {
        public PlayerProgress PlayerProgress { get; set; }

        public List<IPlayerProgressUpdater> ProgressUpdaters { get; private set; } = new List<IPlayerProgressUpdater>();


        public void AddProgressUpdater(IPlayerProgressUpdater progressUpdater)
        {
            ProgressUpdaters.Add(progressUpdater);
        }

        public void AlertAllLoadData()
        {
            foreach(IPlayerProgressUpdater updater in ProgressUpdaters)
            {
                if (updater is IPlayerProgressLoader loader)
                    loader.LoadProgress(PlayerProgress);
            }
        }

        public void AlertAllToUpdateData()
        {
            foreach (IPlayerProgressUpdater updater in ProgressUpdaters)
                updater.UpdateProgress(PlayerProgress);
        }

        public void Cleanup()
        {
            ProgressUpdaters.Clear();
        }
    }
}
