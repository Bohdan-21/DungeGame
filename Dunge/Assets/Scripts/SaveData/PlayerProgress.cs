using Scripts.SaveData.Experience;
using Scripts.SaveData.SkillTree;
using Scripts.SaveData.Stats;
using System;

namespace Scripts.SaveData
{
    [Serializable]
    public class PlayerProgress
    {
        public LevelData LevelData;
        public PlayerState State;
        public Inventory Inventory;
        public PlayerSkillTreeData SkillTreeData;
        public PlayerExperienceData ExperienceData;
        public StatsContainer PlayerStatsContainer;

        public ActiveQuestList ActiveQuestList;

        public PlayerProgress()
        {
            LevelData = new LevelData();
            State = new PlayerState();
            Inventory = new Inventory();
            SkillTreeData = new PlayerSkillTreeData();
            ExperienceData = new PlayerExperienceData();
            PlayerStatsContainer = new StatsContainer();
            ActiveQuestList = new ActiveQuestList();
        }

        public PlayerProgress(LevelData levelData, PlayerState state, Inventory inventory, PlayerSkillTreeData skillTreeData,
                              StatsContainer playerStatsContainer, PlayerExperienceData experienceData)
        {
            LevelData = new LevelData(levelData.CurrentDungeLevel, levelData.MaxReachedDungeLevel);

            State = new PlayerState(state.CurrentHP, state.MaxHP);

            Inventory = new Inventory(inventory);

            SkillTreeData = new PlayerSkillTreeData(skillTreeData);

            ExperienceData = new PlayerExperienceData(experienceData);

            PlayerStatsContainer = new StatsContainer(playerStatsContainer);

            ActiveQuestList = new ActiveQuestList();
        }

        public void ClearAllData()
        {
            Inventory.Clear();
            ActiveQuestList.Clear();
        }
    }
}