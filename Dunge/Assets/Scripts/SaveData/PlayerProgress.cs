using Scripts.SaveData.Experience;
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
        public Storage Storage;
        public PlayerSkillTreeData SkillTreeData;
        public PlayerExperienceData ExperienceData;
        public StatsContainer PlayerStatsContainer;

        public ActiveQuestList ActiveQuestList;

        public PlayerProgress()
        {
            LevelData = new LevelData();
            State = new PlayerState();
            Storage = new Storage();
            SkillTreeData = new PlayerSkillTreeData();
            ExperienceData = new PlayerExperienceData();
            PlayerStatsContainer = new StatsContainer();
            ActiveQuestList = new ActiveQuestList();
        }

        public PlayerProgress(LevelData levelData, PlayerState state, Storage storage, PlayerSkillTreeData skillTreeData,
                              StatsContainer playerStatsContainer, PlayerExperienceData experienceData)
        {
            LevelData = new LevelData(levelData.CurrentDungeLevel, levelData.MaxReachedDungeLevel);

            State = new PlayerState(state.CurrentHP, state.MaxHP);

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