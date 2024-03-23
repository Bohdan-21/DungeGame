using UnityEngine;

namespace Scripts.Services.SettingsService
{
    [CreateAssetMenu(fileName = "DeffaultSettings", menuName = "StaticData/SystemConfigData/DeffaultSettings")]
    public class DeffaultSettings : ScriptableObject
    {
        public SettingsData settingsData;
    }
}
