using System;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.Player
{
    [Serializable]
    [CreateAssetMenu(fileName = "PlayerCharacterConfig", menuName = "StaticData/GameConfigData/Player/PlayerCharacterConfig")]
    public class PlayerCharacterConfig : ScriptableObject
    {
        [Range(1, 25)]
        public float WalkSpeed;

        [Range(1, 20)]
        public int Damage = 20;

        [Range(0.5f, 2f)]
        public float AttackRadius = 1;
    }
}