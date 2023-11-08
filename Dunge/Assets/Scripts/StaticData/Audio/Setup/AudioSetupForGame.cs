using UnityEngine;

namespace Scripts.StaticData.Audio.Setup
{
    [CreateAssetMenu(fileName = "AudioSetupForGame", menuName = "StaticData/Audio/Setup/AudioSetupForGame")]
    public class AudioSetupForGame : ScriptableObject
    {
        public PlayList playList;
        public GameObject BackgroundAudioPlayer;

        public SoundListForGameAction SoundList;
        public GameObject SoundGameActionPlayerPrefab;
    }
}