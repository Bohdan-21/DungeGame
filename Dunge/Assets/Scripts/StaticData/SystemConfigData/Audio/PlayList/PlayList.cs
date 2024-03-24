using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.SystemConfigData.Audio
{
    [Serializable]
    public abstract class PlayList : ScriptableObject
    {
        public List<AudioClip> AudioClips;
    }
}