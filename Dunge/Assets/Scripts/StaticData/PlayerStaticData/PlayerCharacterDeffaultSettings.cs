using Scripts.SaveData;
using Scripts.SaveData.Experience;
using Scripts.SaveData.Money;
using Scripts.SaveData.SkillTree;
using Scripts.SaveData.Stats;
using Scripts.SaveData.Storage;
using System;
using UnityEngine;

namespace Scripts.StaticData.PlayerStaticData
{
    [CreateAssetMenu(fileName = "PlayerCharacterDeffaultSettings", menuName = "StaticData/PlayerCharacterDeffaultSettings")]
    [Serializable]
    public class PlayerCharacterDeffaultSettings : ScriptableObject
    {
        public LevelData LevelData;
        public PlayerState State;
        public MoneyData PlayerMoney;
        public StorageData StorageData;
        public PlayerSkillTreeData SkillTreeData;
        public PlayerExperienceData ExperienceData;
        public StatsContainer PlayerStatsContainer;
    }
}