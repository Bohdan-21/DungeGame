using Scripts.SaveData.PlayerData.Experience;
using Scripts.SaveData.PlayerData.Money;
using Scripts.SaveData.PlayerData.SkillTree;
using Scripts.SaveData.PlayerData.Stats;
using Scripts.SaveData.PlayerData.Storage;
using System;

namespace Scripts.SaveData.PlayerData
{
    [Serializable]
    public class PlayerProgress
    {
        public LevelData LevelData;
        public PlayerState State;
        public MoneyData PlayerMoney;
        public StorageData StorageData;
        public PlayerSkillTreeData SkillTreeData;
        public PlayerExperienceData ExperienceData;
        public StatsContainer PlayerStatsContainer;

        public ActiveQuestList ActiveQuestList;

        public PlayerProgress()
        {
            LevelData = new LevelData();
            State = new PlayerState();
            PlayerMoney = new MoneyData();
            StorageData = new StorageData();
            SkillTreeData = new PlayerSkillTreeData();
            ExperienceData = new PlayerExperienceData();
            PlayerStatsContainer = new StatsContainer();
            ActiveQuestList = new ActiveQuestList();
        }

        public PlayerProgress(LevelData levelData, PlayerState state, MoneyData playerMoney, StorageData storage, PlayerSkillTreeData skillTreeData,
                              StatsContainer playerStatsContainer, PlayerExperienceData experienceData)
        {
            LevelData = new LevelData(levelData.CurrentDungeLevel, levelData.MaxReachedDungeLevel);

            State = new PlayerState(state.CurrentHP, state.MaxHP);

            PlayerMoney = new MoneyData(playerMoney);

            StorageData = new StorageData(storage);

            SkillTreeData = new PlayerSkillTreeData(skillTreeData);

            ExperienceData = new PlayerExperienceData(experienceData);

            PlayerStatsContainer = new StatsContainer(playerStatsContainer);

            ActiveQuestList = new ActiveQuestList();
        }

        public void ClearAllData()
        {
            StorageData.ClearData();
            ActiveQuestList.Clear();
        }
    }
}