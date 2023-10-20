using Scripts.Data.SaveData;
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

        public void Cleanup()
        {
            ProgressUpdaters.Clear();
        }
    }
}
