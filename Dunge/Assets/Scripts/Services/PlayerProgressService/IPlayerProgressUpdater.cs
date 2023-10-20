using Scripts.Data.SaveData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts.Services.PlayerProgressService
{
    public interface IPlayerProgressUpdater
    {
        public void LoadProgress(PlayerProgress playerProgress);

        public void UpdateProgress(PlayerProgress playerProgress);
    }
}
