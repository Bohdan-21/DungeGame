using UnityEngine;
using System.Collections.Generic;
using Scripts.SaveData.Stats;
using Scripts.GameSystem.StatsSystem.Handler;

namespace Scripts.GameSystem.StatsSystem.UI
{
    public class StatCardSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _statCardUIPrefab;
        [SerializeField] private Transform Content;

        private List<GameObject> _spawnedCard = new List<GameObject>();

        public void SpawnCard(PlayerStatsHandler cardData)
        {
            foreach (StatData statData in cardData)
            {
                GameObject card = Instantiate(_statCardUIPrefab, Content);

                card.GetComponent<StatCardUI>().ShowStat(statData);

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
