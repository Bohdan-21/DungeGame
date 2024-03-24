using Scripts.GameSystem.SkillTreeSystem.Handler;
using Scripts.GameSystem.SkillTreeSystem.Type;
using Scripts.GameSystem.StatsSystem.Type;
using Scripts.SaveData.PlayerData;
using Scripts.SaveData.PlayerData.SkillTree;
using Scripts.SaveData.PlayerData.Stats;
using Scripts.Services.PlayerProgressService;
using Scripts.StaticData.GameConfigData.GameSystem.SkillTree.EnumLinks;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.StatsSystem.Handler
{
    public class PlayerStatsHandler : MonoBehaviour, IPlayerProgressLoader
    {
        public static PlayerStatsHandler Instance;

        [SerializeField] private PlayerSkillTreeHandler _skillTreeData;
        [SerializeField] private StatsContainer _playerStatsContainer;

        private ListEnumLinksFromStatToAttribute _staticDataEnumLinks;

        public event Action UpdateStatsEvent;


        [Inject]
        private void Construct(ListEnumLinksFromStatToAttribute staticDataEnumLinks, IPlayerProgressService playerProgressService)
        {
            _staticDataEnumLinks = staticDataEnumLinks;
            playerProgressService.AddProgressUpdater(this);
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _skillTreeData.UpgrateAttributeLevelEvent += RecalculateValueForAttribute;

            RecalculateValueForAttribute();
        }

        public IEnumerator<StatData> GetEnumerator()
        {
            foreach (StatData statData in _playerStatsContainer.Stats)
                yield return statData;
        }

        public StatData GetStatDataByType(TypeStat typeStat)
        {
            foreach (StatData statData in _playerStatsContainer.Stats)
                if (statData.typeStat == typeStat)
                    return statData;
            return null;
        }

        private void RecalculateValueForAttribute()
        {
            foreach (StatData statData in _playerStatsContainer.Stats)
            {
                AttributeType attributeType = _staticDataEnumLinks.GetAttributeType(statData.typeStat);

                if (attributeType != AttributeType.NONE)
                {
                    float boost = FindAttribute(attributeType).GetCurrentBoost();

                    statData.RecalculateCurrentValue(boost);
                }
            }

            UpdateStatsEvent?.Invoke();
        }

        private AttributeData FindAttribute(AttributeType attributeType) =>
            _skillTreeData.GetAttributeDataByType(attributeType);

        public void LoadProgress(PlayerProgress playerProgress)
        {
            _playerStatsContainer = new StatsContainer(playerProgress.PlayerStatsContainer);
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.PlayerStatsContainer = new StatsContainer(_playerStatsContainer);
        }
    }
}
