using System;

namespace Scripts.Data.SaveData
{
    [Serializable]
    public class PlayerProgress
    {
        public LevelData LevelData;
        public State State;
        public Inventory Inventory;
        public ActiveQuestList ActiveQuestList;

        public PlayerProgress()
        {
            LevelData = new LevelData();
            State = new State();
            Inventory = new Inventory();
            ActiveQuestList = new ActiveQuestList();
        }

        public PlayerProgress(LevelData levelData, State state, Inventory inventory)
        {
            LevelData = new LevelData(levelData.CurrentDungeLevel, levelData.MaxReachedDungeLevel);

            State = new State(state.CurrentHP, state.MaxHP);

            Inventory = new Inventory(inventory);

            ActiveQuestList = new ActiveQuestList();
        }

        public void ClearAllData()
        {
            Inventory.Clear();
            ActiveQuestList.Clear();
        }
    }
}