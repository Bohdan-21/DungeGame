using Scripts.SaveData.PlayerData;
using Scripts.SaveData.PlayerData.Experience;
using Scripts.SaveData.PlayerData.Money;
using Scripts.SaveData.PlayerData.SkillTree;
using Scripts.SaveData.PlayerData.Stats;
using Scripts.SaveData.PlayerData.Storage;
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