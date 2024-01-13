using Scripts.GameSystem.SkillTreeSystem.Handler;
using Scripts.GameSystem.SkillTreeSystem.Type;
using Scripts.GameSystem.SkillTreeSystem.UI.Card;
using Scripts.SaveData.SkillTree;
using Scripts.StaticData.GameConfigData.GameSystem.SkillTree.EnumLinks;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.SkillTreeSystem.UI.Spawner
{
    public class AttributeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject AttributeCardPrefab;
        [SerializeField] private Transform Content;

        private List<GameObject> _attributeCards = new List<GameObject>();
        private ListEnumLinksFromAttributeToSkill _enumLinks;

        [Inject]
        private void Construct(ListEnumLinksFromAttributeToSkill enumLinks) => 
            _enumLinks = enumLinks;

        public void SpawnAttributeCards(PlayerSkillTreeHandler skillTreeData, Action RefreshEvent)
        {
            GameObject card;

            foreach (AttributeData attributeData in skillTreeData.GetAttributeData())
            {
                SkillType attributeSkillType = _enumLinks.GetSkillType(attributeData.GetAttributeType());

                card = Instantiate(AttributeCardPrefab, Content);

                card.GetComponent<AttributeCard>().Initialize(attributeData, attributeSkillType, skillTreeData, RefreshEvent);

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