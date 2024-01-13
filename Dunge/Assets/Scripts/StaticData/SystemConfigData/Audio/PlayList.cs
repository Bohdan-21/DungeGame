using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.SystemConfigData.Audio
{
    [CreateAssetMenu(fileName = "PlayList", menuName = "StaticData/SystemConfigData/Audio/PlayList")]
    [Serializable]
    public class PlayList : ScriptableObject
    {
        public List<AudioClip> AudioClips;
    }
}