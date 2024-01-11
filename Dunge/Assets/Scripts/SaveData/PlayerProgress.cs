using Scripts.SaveData.Experience;
using Scripts.SaveData.Money;
using Scripts.SaveData.SkillTree;
using Scripts.SaveData.Stats;
using Scripts.SaveData.Storage;
using System;

namespace Scripts.SaveData
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