using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Data.SaveData
{
    [Serializable]
    public class PlayerProgress
    {
        public LevelData LevelData;
        public State State;
        public Inventory Inventory;

        public PlayerProgress()
        {
            LevelData = new LevelData();
            State = new State();
            Inventory = new Inventory();
        }

        public PlayerProgress(LevelData levelData, State state, Inventory inventory)
        {
            LevelData = new LevelData(levelData.CurrentDungeLevel, levelData.MaxReachedDungeLevel);

            State = new State(state.CurrentHP, state.MaxHP);

            Inventory = new Inventory(inventory);
        }
    }
}