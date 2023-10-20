using Scripts.Data.SaveData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.PlayerStaticData
{
    [CreateAssetMenu(fileName = "PlayerCharacterDeffaultSettings", menuName = "StaticData/PlayerCharacterDeffaultSettings")]
    [Serializable]
    public class PlayerCharacterDeffaultSettings : ScriptableObject
    {
        public LevelData LevelData;
        public State State;
        public Inventory Inventory;
    }
}