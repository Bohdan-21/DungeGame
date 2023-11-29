using Scripts.GameSystem.ExperienceSystem.Handler;
using Scripts.GameSystem.SkillTreeSystem.Type;
using Scripts.SaveData.SkillTree;
using Scripts.StaticData.EnemyStaticData;
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
        private void Construct(EnemyCharacterDeffaultSettings deffaultSettings)
        {
            _enemySkillTreeData = new EnemySkillTreeData(deffaultSettings.EnemySkillTreeData);
        }

        private void Awake()
        {
            _enemyExperienceHandler.LevelUpEvent += LevelUpEvent;
        }

        private void OnDestroy()
        {
            _enemyExperienceHandler.LevelUpEvent -= LevelUpEvent;            
        }


        private void LevelUpEvent()
        {
            int indexAttribute = GetRandomIndex();

            AttributeData attributeData = _enemySkillTreeData.attributes[indexAttribute];

            if (attributeData.CanUpgrateLevel())
            {
                attributeData.UpLevel();
                UpdateAttributeLevelEvent?.Invoke();
            }
            else
                LevelUpEvent();
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