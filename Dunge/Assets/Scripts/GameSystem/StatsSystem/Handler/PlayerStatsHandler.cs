using Scripts.GameSystem.SkillTreeSystem.Handler;
using Scripts.GameSystem.SkillTreeSystem.Type;
using Scripts.GameSystem.StatsSystem.Type;
using Scripts.SaveData;
using Scripts.SaveData.SkillTree;
using Scripts.SaveData.Stats;
using Scripts.Services.PlayerProgressService;
using Scripts.Stats.Data;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.StatsSystem.Handler
{
    public class PlayerStatsHandler : MonoBehaviour, IPlayerProgressLoader
    {
        public static PlayerStatsHandler Instance;

        [SerializeField] private SkillTreeHandler _skillTreeData;
        [SerializeField] private PlayerStatsContainer _playerStatsContainer;

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
            foreach (StatData statData in _playerStatsContainer.PlayerStats)
                yield return statData;
        }

        public StatData GetStatDataByType(TypeStat typeStat)
        {
            foreach (StatData statData in _playerStatsContainer.PlayerStats)
                if (statData.typeStat == typeStat)
                    return statData;
            return null;
        }

        private void RecalculateValueForAttribute()
        {
            foreach (StatData statData in _playerStatsContainer.PlayerStats)
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
            _playerStatsContainer = new PlayerStatsContainer(playerProgress.PlayerStatsContainer);
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.PlayerStatsContainer = new PlayerStatsContainer(_playerStatsContainer);
        }
    }
}
