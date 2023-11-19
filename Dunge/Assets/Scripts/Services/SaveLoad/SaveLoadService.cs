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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
            CleanAllPlayerProgress();

            foreach (IPlayerProgressUpdater progressUpdater in _playerProgressService.ProgressUpdaters)
                progressUpdater.UpdateProgress(_playerProgressService.PlayerProgress);

            BinarySerializer.Serialize(_playerProgressService.PlayerProgress, "/data.dat");

            /*PlayerPrefs.SetString(Key, _playerProgressService.PlayerProgress.ToJson());
            PlayerPrefs.Save();*/
        }

        public PlayerProgress LoadProgress()
        {
            return BinarySerializer.Deserialize<PlayerProgress>("/data.dat");
            //return PlayerPrefs.GetString(Key).FromJson<PlayerProgress>();
        }

        private void CleanAllPlayerProgress()
        {
            _playerProgressService.PlayerProgress.ClearAllData();
        }
    }

    public static class BinarySerializer
    {
        public static void Serialize(object data, string fileName)
        {
            using (FileStream stream = new FileStream("E:" + fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, data);
            }
        }

        public static T Deserialize<T>(string fileName)
        {
            using (FileStream stream = new FileStream("E:" + fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                T data = (T) formatter.Deserialize(stream);

                return data;
            }
        }
    }
}
