using UnityEngine;
using System.Collections.Generic;
using Scripts.GameSystem.StatsSystem.Handler;
using Zenject;
using Scripts.StaticData.LanguageLocalizationConfigData.LocalizationForStat;
using Scripts.Services.LanguageService;
using Scripts.SaveData.PlayerData.Stats;

namespace Scripts.GameSystem.StatsSystem.UI
{
    public class StatCardSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _statCardUIPrefab;
        [SerializeField] private Transform Content;

        private List<GameObject> _spawnedCard = new List<GameObject>();

        private LocalizationForStatType _localizationForStatType;
        private ILanguageService _languageSettings;

        [Inject]
        private void Construct(LocalizationForStatType localizationForStatType, ILanguageService languageSettings)
        {
            _localizationForStatType = localizationForStatType;
            _languageSettings = languageSettings;
        }

        public void SpawnCard(PlayerStatsHandler cardData)
        {
            string localizationText;

            foreach (StatData statData in cardData)
            {
                GameObject card = Instantiate(_statCardUIPrefab, Content);

                localizationText = _localizationForStatType.GetLocalizationText(statData.typeStat, _languageSettings.Language);

                card.GetComponent<StatCardUI>().ShowStat(statData, localizationText);

                _spawnedCard.Add(card);
            }
        }

        public void ClearAll()
        {
            foreach (GameObject card in _spawnedCard)
                Destroy(card);
            _spawnedCard.Clear();
        }
    }
}
