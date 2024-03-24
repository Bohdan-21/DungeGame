using Scripts.SaveData.SettingsData;
using UnityEngine;

namespace Scripts.StaticData.SystemConfigData.Settings
{
    [CreateAssetMenu(fileName = "DefaultSettings", menuName = "StaticData/SystemConfigData/Settings/DefaultSettings")]
    public class DefaultGameSettings : ScriptableObject
    {
        public SettingsData settingsData;
    }
}
