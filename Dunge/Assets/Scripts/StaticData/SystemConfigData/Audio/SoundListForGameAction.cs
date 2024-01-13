using System;
using UnityEngine;

namespace Scripts.StaticData.SystemConfigData.Audio
{
    [CreateAssetMenu(fileName = "SoundListForGameAction", menuName = "StaticData/SystemConfigData/Audio/SoundListForGameAction")]
    [Serializable]
    public class SoundListForGameAction : ScriptableObject
    {
        public AudioClip UseItemSound;

        public AudioClip AttackPlayerSound;

        public AudioClip AttackEnemySound;

        public AudioClip HitPlayerSound;

        public AudioClip HitEnemySound;

        public AudioClip TeleportSound;

        public AudioClip PlayerLose;

        public AudioClip EnemyDeath;

        public AudioClip PickUpItemSound;
    }
}
