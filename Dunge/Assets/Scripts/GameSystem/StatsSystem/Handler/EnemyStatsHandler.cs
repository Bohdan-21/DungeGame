using Scripts.GameSystem.SkillTreeSystem.Handler;
using Scripts.GameSystem.SkillTreeSystem.Type;
using Scripts.GameSystem.StatsSystem.Type;
using Scripts.SaveData.SkillTree;
using Scripts.SaveData.Stats;
using Scripts.StaticData.GameConfigData.Enemy;
using Scripts.StaticData.GameConfigData.GameSystem.SkillTree.EnumLinks;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.StatsSystem.Handler
{
    public class EnemyStatsHandler : MonoBehaviour
    {
        [SerializeField] private EnemySkillTreeHandler _enemySkillTreeHandler;
        [SerializeField] private StatsContainer _enemyStatsContainer;

        private ListEnumLinksFromStatToAttribute _staticDataEnumLinks;

        public event Action UpdateStatsEvent;

        [Inject]
        private void Construct(ListEnumLinksFromStatToAttribute enumLinks, 
                               DeffaultSettingsForNewEnemy deffaultSettings)
        {
            _staticDataEnumLinks = enumLinks;
            _enemyStatsContainer = new StatsContainer(deffaultSettings.EnemyStatsContainer);
        }

        //TODO: fix ЭТО НУЖНО ПЕРЕПИСАТЬ
        //это неправильно. Вообще то что это работает это чудо. А главное то что этот костиль 
        //хрен уберешь, по этому действуем по старинке. Работает не трогай. Но это нужно переписать!
        //ебушки воробушки какого хуя оно вообще работает, там же дальше идет вызов еще одного ивента
        private void Awake()
        {
            _enemySkillTreeHandler.UpdateAttributeLevelEvent += UpdateAttributeLevelEvent;
        }

        private void OnDestroy()
        {
            _enemySkillTreeHandler.UpdateAttributeLevelEvent -= UpdateAttributeLevelEvent;
        }

        public StatData GetStatDataByType(TypeStat typeStat)
        {
            foreach (StatData statData in _enemyStatsContainer.Stats)
                if (statData.typeStat == typeStat)
                    return statData;
            return null;
        }

        private void UpdateAttributeLevelEvent()
        {
            RecalculateValueForAttribute();
        }

        private void RecalculateValueForAttribute()
        {
            foreach(StatData statData in _enemyStatsContainer.Stats)
            {
                AttributeType attributeType = _staticDataEnumLinks.GetAttributeType(statData.typeStat);

                if(attributeType != AttributeType.NONE)
                {
                    float boost = FindAttribute(attributeType).GetCurrentBoost();
                    statData.RecalculateCurrentValue(boost);
                }
            }

            UpdateStatsEvent?.Invoke();
        }

        private AttributeData FindAttribute(AttributeType attributeType) => 
            _enemySkillTreeHandler.GetAttributeDataByType(attributeType);
    }
}
