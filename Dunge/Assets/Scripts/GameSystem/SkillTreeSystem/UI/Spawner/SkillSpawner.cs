using Scripts.GameSystem.SkillTreeSystem.Handler;
using Scripts.GameSystem.SkillTreeSystem.UI.Card;
using Scripts.LanguageLocalization.Service;
using Scripts.SaveData.SkillTree;
using Scripts.StaticData.LanguageLocalizationConfigData.LocalizationForSkillTree;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.SkillTreeSystem.UI.Spawner
{
    public class SkillSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject SkillCardPrefab;
        [SerializeField] private Transform Content;

        private List<GameObject> _skillCards = new List<GameObject>();
        private LocalizationForSkillType _localizationForSkillType;
        private ILanguageSettings _languageSettings;

        [Inject]
        private void Construct(LocalizationForSkillType localizationForSkillType, ILanguageSettings languageSettings)
        {
            _localizationForSkillType = localizationForSkillType;
            _languageSettings = languageSettings;
        }

        public void SpawnSkillCards(PlayerSkillTreeHandler skillTreeData, Action RefreshEvent)
        {
            GameObject card;
            string localizationTextForSkill;

            foreach (SkillData skillData in skillTreeData.GetSkillData())
            {
                card = Instantiate(SkillCardPrefab, Content);

                localizationTextForSkill = _localizationForSkillType.GetLocalizationText(skillData.SkillType, _languageSettings.Language);

                card.GetComponent<SkillCard>().Initialize(skillData, localizationTextForSkill, skillTreeData, RefreshEvent);

                _skillCards.Add(card);
            }
        }

        public void ClearAll()
        {
            foreach (GameObject card in _skillCards)
                Destroy(card);
            _skillCards.Clear();
        }
    }
}