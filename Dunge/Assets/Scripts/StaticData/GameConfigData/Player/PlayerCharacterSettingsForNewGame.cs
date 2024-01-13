using Scripts.SaveData;
using Scripts.SaveData.Experience;
using Scripts.SaveData.Money;
using Scripts.SaveData.SkillTree;
using Scripts.SaveData.Stats;
using Scripts.SaveData.Storage;
using System;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.Player
{
    [CreateAssetMenu(fileName = "PlayerCharacterSettingsForNewGame", menuName = "StaticData/GameConfigData/Player/PlayerCharacterSettingsForNewGame")]
    [Serializable]
    public class PlayerCharacterSettingsForNewGame : ScriptableObject
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