using System;
using UnityEngine;

namespace Scripts.StaticData.SystemConfigData.Audio
{
    [CreateAssetMenu(fileName = "AudioSettings", menuName = "StaticData/SystemConfigData/Audio/AudioSettings")]
    [Serializable]
    public class AudioSetting : ScriptableObject
    {
        [Range(0f, 1f)]
        public float MusicVolume = 0.5f;

        [Range(0f, 1f)]
        public float SoundVolume = 0.5f;
    }
}