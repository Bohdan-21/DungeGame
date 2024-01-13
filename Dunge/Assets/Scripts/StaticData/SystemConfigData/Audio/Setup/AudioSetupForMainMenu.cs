using Scripts.StaticData.SystemConfigData.Audio;
using UnityEngine;

namespace Scripts.StaticData.SystemConfigData.Audio.Setup
{
    [CreateAssetMenu(fileName = "AudioSetupForMainMenu", menuName = "StaticData/SystemConfigData/Audio/Setup/AudioSetupForMainMenu")]
    public class AudioSetupForMainMenu : ScriptableObject
    {
        public PlayList PlayList;
        public GameObject BackGroundAudioPlayer;
    }
}