using Scripts.SaveData;
using Scripts.SaveData.Experience;
using Scripts.SaveData.SkillTree;
using Scripts.SaveData.Stats;
using System;
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
        public SkillTreeData SkillTreeData;
        public ExperienceData ExperienceData;
        public PlayerStatsContainer PlayerStatsContainer;
    }
}