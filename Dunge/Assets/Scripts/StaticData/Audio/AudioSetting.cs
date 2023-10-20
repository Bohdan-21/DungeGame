using System;
using UnityEngine;

namespace Scripts.StaticData.Audio
{
    [CreateAssetMenu(fileName = "AudioSettings", menuName = "StaticData/AudioSettings")]
    [Serializable]
    public class AudioSetting : ScriptableObject
    {
        [Range(0f, 1f)]
        public float MusicVolume = 0.5f;

        [Range(0f, 1f)]
        public float SoundVolume = 0.5f;
    }
}