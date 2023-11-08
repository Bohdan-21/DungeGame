using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.Audio
{
    [CreateAssetMenu(fileName = "PlayList", menuName = "StaticData/Audio/PlayList")]
    [Serializable]
    public class PlayList : ScriptableObject
    {
        public List<AudioClip> AudioClips;
    }
}