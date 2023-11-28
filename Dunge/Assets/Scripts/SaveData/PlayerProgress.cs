using Scripts.GameSystem.SkillTreeSystem.Logic;
using System;

namespace Scripts.Data.SaveData
{
    [Serializable]
    public class PlayerProgress
    {
        public LevelData LevelData;
        public State State;
        public Inventory Inventory;
        public SkillTreeData SkillTreeData;
        public ActiveQuestList ActiveQuestList;

        public PlayerProgress()
        {
            LevelData = new LevelData();
            State = new State();
            Inventory = new Inventory();
            SkillTreeData = new SkillTreeData();
            ActiveQuestList = new ActiveQuestList();
        }

        public PlayerProgress(LevelData levelData, State state, Inventory inventory, SkillTreeData skillTreeData)
        {
            LevelData = new LevelData(levelData.CurrentDungeLevel, levelData.MaxReachedDungeLevel);

            State = new State(state.CurrentHP, state.MaxHP);

            Inventory = new Inventory(inventory);

            SkillTreeData = new SkillTreeData(skillTreeData);

            ActiveQuestList = new ActiveQuestList();
        }

        public void ClearAllData()
        {
            Inventory.Clear();
            ActiveQuestList.Clear();
        }
    }
}