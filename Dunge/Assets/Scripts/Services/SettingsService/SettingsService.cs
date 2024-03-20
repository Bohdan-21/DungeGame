using Scripts.Services.AudioService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Services.SettingsService
{
    public class SettingsData
    {
        public AudioData audioData;
    }

    public class AudioData
    {
        public float soundVolume;
        public float musicVolume;
    }

    [CreateAssetMenu(fileName = "DeffaultSettings", menuName = "StaticData/DeffaultSettings")]
    public class DeffaultSettings : ScriptableObject
    {
        public SettingsData settingsData;
    }


    public class SaveLoadSettingsService
    {
        public void Save(SettingsData settingsData)
        {
            throw new NotImplementedException();
        }

        public SettingsData Load()
        {
            throw new NotImplementedException();
        }
    }

    public class SettingsService
    {
        private List<ISettingService> _settingServices = new List<ISettingService>();
        
        public SettingsData SettingsData { get; set; }
                
        public void AddService(ISettingService service)
        {
            _settingServices.Add(service);
        }
        
        public void RemoveService(ISettingService service)
        {
            _settingServices.Remove(service);
        }

        public void AllertAllUpdateSettings()
        {
            foreach(ISettingService service in _settingServices)
            {
                service.UpdateSettings(SettingsData);
            }
        }

        public void AllertAllLoadSettings()
        {
            foreach(ISettingService service in _settingServices)
            {
                service.LoadSettings(SettingsData);
            }
        }
    }
}
