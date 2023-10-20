using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.StaticData.Audio
{
    [CreateAssetMenu(fileName = "SoundListForButtonAction", menuName = "StaticData/SoundListForButtonAction")]
    [Serializable]
    public class SoundListForButtonAction : ScriptableObject
    {
        public AudioClip ButtonPressSound;

        public AudioClip PauseSound;

        public AudioClip UnpauseSound;
    }
}
