using Scripts.GameSystem.SkillTreeSystem.Handler;
using Scripts.GameSystem.SkillTreeSystem.UI.Card;
using Scripts.SaveData.SkillTree;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.GameSystem.SkillTreeSystem.UI.Spawner
{
    public class SkillSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject SkillCardPrefab;
        [SerializeField] private Transform Content;

        private List<GameObject> _skillCards = new List<GameObject>();

        public void SpawnSkillCards(SkillTreeHandler skillTreeData, Action RefreshEvent)
        {
            GameObject card;

            foreach (SkillData skillData in skillTreeData.GetSkillData())
            {
                card = Instantiate(SkillCardPrefab, Content);

                card.GetComponent<SkillCard>().Initialize(skillData, skillTreeData, RefreshEvent);

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