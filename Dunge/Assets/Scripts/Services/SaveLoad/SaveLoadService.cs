using Scripts.Data.SaveData;
using Scripts.Extension;
using Scripts.Infrastructure.Factory;
using Scripts.Services.PlayerProgressService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string Key = "Progress";

        private readonly IPlayerProgressService _playerProgressService;

        public SaveLoadService(IPlayerProgressService playerProgressService)
        {
            _playerProgressService = playerProgressService;
        }

        public void SaveProgress()
        {
            foreach (IPlayerProgressUpdater progressUpdater in _playerProgressService.ProgressUpdaters)
                progressUpdater.UpdateProgress(_playerProgressService.PlayerProgress);

            PlayerPrefs.SetString(Key, _playerProgressService.PlayerProgress.ToJson());
            PlayerPrefs.Save();
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(Key).FromJson<PlayerProgress>();
        }
    }
}
