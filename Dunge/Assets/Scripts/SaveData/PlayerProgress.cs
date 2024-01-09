using Scripts.SaveData.Experience;
using Scripts.SaveData.Money;
using Scripts.SaveData.SkillTree;
using Scripts.SaveData.Stats;
using Scripts.SaveData.StorageData;
using System;

namespace Scripts.SaveData
{
    [Serializable]
    public class PlayerProgress
    {
        public LevelData LevelData;
        public PlayerState State;
        public MoneyData PlayerMoney;
        public Storage Storage;
        public PlayerSkillTreeData SkillTreeData;
        public PlayerExperienceData ExperienceData;
        public StatsContainer PlayerStatsContainer;

        public ActiveQuestList ActiveQuestList;

        public PlayerProgress()
        {
            LevelData = new LevelData();
            State = new PlayerState();
            PlayerMoney = new MoneyData();
            Storage = new Storage();
            SkillTreeData = new PlayerSkillTreeData();
            ExperienceData = new PlayerExperienceData();
            PlayerStatsContainer = new StatsContainer();
            ActiveQuestList = new ActiveQuestList();
        }

        public PlayerProgress(LevelData levelData, PlayerState state, MoneyData playerMoney, Storage storage, PlayerSkillTreeData skillTreeData,
                              StatsContainer playerStatsContainer, PlayerExperienceData experienceData)
        {
            LevelData = new LevelData(levelData.CurrentDungeLevel, levelData.MaxReachedDungeLevel);

            State = new PlayerState(state.CurrentHP, state.MaxHP);

            PlayerMoney = new MoneyData(playerMoney);

            Storage = new Storage(storage);

            SkillTreeData = new PlayerSkillTreeData(skillTreeData);

            ExperienceData = new PlayerExperienceData(experienceData);

            PlayerStatsContainer = new StatsContainer(playerStatsContainer);

            ActiveQuestList = new ActiveQuestList();
        }

        public void ClearAllData()
        {
            Storage.ClearData();
            ActiveQuestList.Clear();
        }
    }
}