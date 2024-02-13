using Scripts.GameSystem.SkillTreeSystem.Handler;
using Scripts.GameSystem.SkillTreeSystem.Type;
using Scripts.GameSystem.SkillTreeSystem.UI.Card;
using Scripts.LanguageLocalization.Service;
using Scripts.SaveData.SkillTree;
using Scripts.StaticData.GameConfigData.GameSystem.SkillTree.EnumLinks;
using Scripts.StaticData.LanguageLocalizationConfigData.LocalizationForSkillTree;
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
        private ILanguageSettings _languageSettings;
        private LocalizationForSkillType _localizationForSkillType;
        private LocalizationForAttributeType _localizationForAttributeType;

        [Inject]
        private void Construct(ListEnumLinksFromAttributeToSkill enumLinks, LocalizationForAttributeType localizationForAttributeType, 
                               LocalizationForSkillType localizationForSkillType, ILanguageSettings languageSettings)
        {
            _enumLinks = enumLinks;
            _languageSettings = languageSettings;
            _localizationForSkillType = localizationForSkillType;
            _localizationForAttributeType = localizationForAttributeType;
        }

        public void SpawnAttributeCards(PlayerSkillTreeHandler skillTreeData, Action RefreshEvent)
        {
            GameObject card;
            string localizationTextForSkill;
            string localizationTextForAttribute;

            foreach (AttributeData attributeData in skillTreeData.GetAttributeData())
            {
                SkillType attributeSkillType = _enumLinks.GetSkillType(attributeData.GetAttributeType());

                card = Instantiate(AttributeCardPrefab, Content);

                localizationTextForSkill = _localizationForSkillType.GetLocalizationText(attributeSkillType, _languageSettings.Language);
                localizationTextForAttribute = _localizationForAttributeType.GetLocalizationText(attributeData.AttributeType, _languageSettings.Language);

                card.GetComponent<AttributeCard>().Initialize(attributeData, skillTreeData, localizationTextForSkill, 
                                                              localizationTextForAttribute, RefreshEvent);

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