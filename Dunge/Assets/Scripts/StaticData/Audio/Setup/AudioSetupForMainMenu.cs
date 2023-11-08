using Scripts.StaticData.Audio;
using UnityEngine;

namespace Scripts.StaticData.Audio.Setup
{
    [CreateAssetMenu(fileName = "AudioSetupForMainMenu", menuName = "StaticData/Audio/Setup/AudioSetupForMainMenu")]
    public class AudioSetupForMainMenu : ScriptableObject
    {
        public PlayList PlayList;
        public GameObject BackGroundAudioPlayer;
    }
}