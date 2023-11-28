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
        public SkillTreeData SkillTreeData;
        public ExperienceData ExperienceData;
        public PlayerStatsContainer PlayerStatsContainer;

        public ActiveQuestList ActiveQuestList;

        public PlayerProgress()
        {
            LevelData = new LevelData();
            State = new PlayerState();
            Inventory = new Inventory();
            SkillTreeData = new SkillTreeData();
            ExperienceData = new ExperienceData();
            PlayerStatsContainer = new PlayerStatsContainer();
            ActiveQuestList = new ActiveQuestList();
        }

        public PlayerProgress(LevelData levelData, PlayerState state, Inventory inventory, SkillTreeData skillTreeData,
                              PlayerStatsContainer playerStatsContainer, ExperienceData experienceData)
        {
            LevelData = new LevelData(levelData.CurrentDungeLevel, levelData.MaxReachedDungeLevel);

            State = new PlayerState(state.CurrentHP, state.MaxHP);

            Inventory = new Inventory(inventory);

            SkillTreeData = new SkillTreeData(skillTreeData);

            ExperienceData = new ExperienceData(experienceData);

            PlayerStatsContainer = new PlayerStatsContainer(playerStatsContainer);

            ActiveQuestList = new ActiveQuestList();
        }

        public void ClearAllData()
        {
            Inventory.Clear();
            ActiveQuestList.Clear();
        }
    }
}