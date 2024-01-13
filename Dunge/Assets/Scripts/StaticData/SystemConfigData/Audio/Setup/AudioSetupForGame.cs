using UnityEngine;

namespace Scripts.StaticData.SystemConfigData.Audio.Setup
{
    [CreateAssetMenu(fileName = "AudioSetupForGame", menuName = "StaticData/SystemConfigData/Audio/Setup/AudioSetupForGame")]
    public class AudioSetupForGame : ScriptableObject
    {
        public PlayList playList;
        public GameObject BackgroundAudioPlayer;

        public SoundListForGameAction SoundList;
        public GameObject SoundGameActionPlayerPrefab;
    }
}