using Scripts.GameSystem.ExperienceSystem.Handler;
using Scripts.GameSystem.SkillTreeSystem.Data;
using Scripts.GameSystem.SkillTreeSystem.Type;
using Scripts.SaveData.SkillTree;
using Scripts.StaticData.GameConfigData.Enemy;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.SkillTreeSystem.Handler
{
    public class EnemySkillTreeHandler : MonoBehaviour
    {
        [SerializeField] private EnemyExperienceHandler _enemyExperienceHandler;
        [SerializeField] private EnemySkillTreeData _enemySkillTreeData;

        public event Action UpdateAttributeLevelEvent;

        [Inject]
        private void Construct(DeffaultSettingsForNewEnemy deffaultSettings)
        {
            _enemySkillTreeData = new EnemySkillTreeData(deffaultSettings.EnemySkillTreeData);
        }

        private void Start()
        {
            for (int i = 0; i < _enemyExperienceHandler.GetCurrentLevel(); i++)
                LevelUp();
        }


        private void LevelUp()
        {
            int indexAttribute = GetRandomIndex();

            AttributeData attributeData = _enemySkillTreeData.attributes[indexAttribute];

            if (attributeData.CanUpgrateLevel())
            {
                attributeData.UpLevel();
                UpdateAttributeLevelEvent?.Invoke();
            }
            else
                LevelUp();
        }

        private int GetRandomIndex() => 
            UnityEngine.Random.Range(0, _enemySkillTreeData.attributes.Count);

        public AttributeData GetAttributeDataByType(AttributeType attributeType)
        {
            foreach (AttributeData attributeData in _enemySkillTreeData.attributes)
                if (attributeData.GetAttributeType() == attributeType)
                    return attributeData;
            return null;
        }
    }
}