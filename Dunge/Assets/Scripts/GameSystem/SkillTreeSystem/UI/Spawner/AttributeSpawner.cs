using Scripts.GameSystem.SkillTreeSystem.Handler;
using Scripts.GameSystem.SkillTreeSystem.UI.Card;
using Scripts.SaveData.SkillTree;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.GameSystem.SkillTreeSystem.UI.Spawner
{
    public class AttributeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject AttributeCardPrefab;
        [SerializeField] private Transform Content;

        private List<GameObject> _attributeCards = new List<GameObject>();

        public void SpawnAttributeCards(PlayerSkillTreeHandler skillTreeData, Action RefreshEvent)
        {
            GameObject card;

            foreach (AttributeData attributeData in skillTreeData.GetAttributeData())
            {
                card = Instantiate(AttributeCardPrefab, Content);

                card.GetComponent<AttributeCard>().Initialize(attributeData, skillTreeData, RefreshEvent);

                _attributeCards.Add(card);
            }
        }

        public void ClearAll()
        {
            foreach (GameObject card in _attributeCards)
                Destroy(card);
            _attributeCards.Clear();
        }
    }
}